using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ArtistAPI.Models;
using ArtistAPI.Services.MusicBrainz;
using Newtonsoft.Json;

namespace ArtistAPI.Services
{
    public class SearchMusicBrainzReleaseSvc: ISearchMusicBrainzReleaseSvc
    {
        public List<Release> GetReleaseByMusicBrainz(string artistId)
        {
            string pathApi = String.Format("http://musicbrainz.org/ws/2/release/?query=arid:{0}&fmt=json", artistId);
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");
            string data = webClient.DownloadString(pathApi);

            dynamic responseData = JsonConvert.DeserializeObject(data);

            List<Release> releases = new List<Release>();
            for (int i = 0; i < responseData.releases.Count; i++)
            {
                List<ArtistWithIdAndNameOnly> otherArtists = new List<ArtistWithIdAndNameOnly>();
                var rawData = responseData.releases;
                var rawOtherArtists = rawData[i]["artist-credit"];
                foreach (var artist in rawOtherArtists)
                {
                    otherArtists.Add(new ArtistWithIdAndNameOnly()
                    {
                        Id = artist.artist.id,
                        Name = artist.artist.name
                    });
                }

                string label = rawData[i]["label-info"] == null
                    ? string.Empty
                    : (rawData[i]["label-info"][rawData[i]["label-info"].Count - 1] == null
                        ? string.Empty
                        : (rawData[i]["label-info"][rawData[i]["label-info"].Count - 1].label == null
                            ? string.Empty
                            : (rawData[i]["label-info"][rawData[i]["label-info"].Count - 1].label.name == null
                                ? string.Empty
                                : rawData[i]["label-info"][rawData[i]["label-info"].Count - 1].label.name)));

                string releaseId = rawData[i].id;
                string title = rawData[i].title;
                string status = rawData[i].status;
                int numberOfTracks = rawData[i]["track-count"];

                releases.Add(new Release()
                {
                    ReleaseId = releaseId,
                    Title = title,
                    Status = status,
                    Label = label,
                    NumberOfTracks = numberOfTracks,
                    OtherArtists = otherArtists
                });
            }

            return releases;
        }

        public List<Album> GetAlbumsByMusicBrainz(string artistId)
        {
            string pathApi = String.Format("https://musicbrainz.org/ws/2/release-group/?query=arid:{0}&fmt=json", artistId);
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");
            string data = webClient.DownloadString(pathApi);

            dynamic responseData = JsonConvert.DeserializeObject(data);

            var releaseGroup = responseData["release-groups"];

            List<Album> albums = new List<Album>();

            foreach (var rg in releaseGroup)
            {
                if(rg["primary-type"] != null)
                    if(rg["primary-type"].ToString().ToLower() == "album")
                        albums.Add(new Album()
                        {
                            Id = rg.id,
                            Title = rg.title == null ? string.Empty : rg.title
                        });
            }

            return albums;
        }
    }
}
