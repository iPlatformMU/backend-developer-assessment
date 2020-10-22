using APIArtist.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIArtist.Services
{
    public class ArtistService : IArtistService
    {
        private readonly DBArtistEntities entity = new DBArtistEntities();
        private readonly string _musicbrainzURI = "https://musicbrainz.org/ws/2/release";
        public IQueryable<Artist> GetArtists()
        {
            return entity?.Artists;
        }

        public Artist GetArtistById(Guid id)
        {
            return entity.Artists?.SingleOrDefault(a => a.ArtisteId == id);
        }

        public ArtistResult SearchArtist(string criteria, int pageNumber , int pageSize)
        {
            //Set defaults max values for pagination
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize > 10 ? 10 : pageSize;

            //get list from database
            var artists = (from a in entity.Artists
                           where a.ArtisteName.Contains(criteria.ToLower()) || a.Aliases.Contains(criteria.ToLower())
                           select a)
                        .OrderBy(p => p.ArtisteId)
                        .Skip(((pageNumber - 1) * pageSize))
                        .Take(pageSize)
                        .ToList()
                        .Where(artist => artist.ArtisteName.ToLower().StartsWith(criteria.ToLower())
                                 || artist.Aliases.Split(',')
                                     .Where(alias => alias.ToLower().StartsWith(criteria.ToLower())).ToList().Count > 0).ToList();
                    
            List<ArtistInfo> artistsInfo = new List<ArtistInfo>();

            //create a list of ArtistInfo Object 
            foreach (var info in artists)
            {
                string[] aliases = info.Aliases?.Split(',');
                artistsInfo.Add(
                    new ArtistInfo()
                    {
                        Name = info.ArtisteName,
                        Country = info.Country,
                        Alias = aliases
                    }
                );
            }

            //create ArtistResult object
            ArtistResult result = new ArtistResult()
            {
                Results = artistsInfo,
                NumberOfSearchResults = artistsInfo.Count,
                Page = pageNumber,
                NumberOfPages = pageSize
            };

            return result;
        }

        //Function To get response from External API
        private static async Task<dynamic> GetExternalAPI(string url)
        {
            var client = new HttpClient() { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders.Add("User-Agent", "Only a test!");
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };

            HttpResponseMessage response = await client.GetAsync("", HttpCompletionOption.ResponseContentRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            string data = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject(data);
            return result;
        }

        public List<Albums> GetTopAlbums(Guid artistId)
        {
            string address = String.Format(_musicbrainzURI + "-group?artist=" + artistId + "&type=album&limit=10&fmt=json");
            var data = GetExternalAPI(address).Result; //response from external API

            List<Albums> albums = new List<Albums>();

            //Create List of Album Object
            foreach (var album in data["release-groups"])
            {
                albums.Add(
                    new Albums()
                    {
                        Title = album.title,
                        DateRelease = album["first-release-date"]
                    }
                );
            }
            return albums;
        }

        public List<Releases> GetReleases(Guid artistId)
        {
            string address = String.Format(_musicbrainzURI + "/?query=arid:" + artistId + "&fmt=json&limit=100");

            var dataFromMusicbrainz = GetExternalAPI(address).Result; //Data response from exteral API

            List<Releases> releases = new List<Releases>();

            //Create List of releases Object
            foreach(var release in dataFromMusicbrainz.releases)
            {
                List<ArtistInfo> artistCredit = new List<ArtistInfo>();

                //get the artists on the releases
                if (release["artist-credit"].Count > 0)
                {
                    foreach (var info in release["artist-credit"])
                    {
                        artistCredit.Add(
                            new ArtistInfo()
                            {
                                Id = info.artist.id,
                                Name = info.artist.name
                            }
                        );
                    }
                }                       

                //Releases Object
                releases.Add(
                    new Releases()
                    {
                        ReleaseId = release.id,
                        Title = release.title,
                        Status = release.status,
                        Label = release["label-info"]?[0]?.label?.name?.ToString(),
                        NumberOfTracks = release["track-count"],
                        OtherArtist = artistCredit
                    }
                );
            }

            return releases;
        }
    }
}