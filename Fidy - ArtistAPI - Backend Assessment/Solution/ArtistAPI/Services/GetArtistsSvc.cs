using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using ArtistAPI.Models;
using Newtonsoft.Json;

namespace ArtistAPI.Services
{
    public class GetArtistsSvc: IGetArtistSvc
    {
        private DB_ArtistsEntities db = new DB_ArtistsEntities();

        public IQueryable<Artist> GetArtists()
        {
            return db.Artist;
        }

        public Artist GetArtist(string id)
        {
            Artist artist = db.Artist.Find(id);
            if (artist == null)
            {
                return null;
            }

            return artist;
        }

        public SearchArtists GetArtistsByCriteria(string criteria, int pageNumber, int pageSize)
        {
            // From IQueriable Artist that have a name starting with <criteria> || aliases that contains criteria in its aliases(Aliases is a string), select Artist
            List<Artist> artists = (from artist in db.Artist
                                    where artist.artistName.Trim().ToLower().StartsWith(criteria.Trim().ToLower())
                                    || artist.artistName.Trim().ToLower().Contains(criteria.Trim().ToLower())
                                    select artist).ToList();
            // From List Artist, select Artist that has a name or one of their aliases starting with <criteria>
            List<Artist> outputArtists = artists
                .Where(artist => artist.artistName.Trim().ToLower().StartsWith(criteria.Trim().ToLower())
                    || artist.artistAliases.Split(',')
                    .Where(aliase => aliase.Trim().ToLower().StartsWith(criteria.Trim().ToLower())).ToList().Count > 0).ToList();

            // Format artist to fit with the expected JSON result
            List<ArtistWithoutId> formatedOutputArtists = new List<ArtistWithoutId>();

            foreach (Artist artist in outputArtists)
            {
                string[] aliases = artist.artistAliases.Split(',')
                        .Select(alias => alias.Length > 0
                            ? alias.Trim()                                      //Remove white spaces 
                            : "").ToArray()
                            .Where(alias => alias.ToString() != "").ToArray();  // Remove empty string so we can have [] but not [""] in the output list

                formatedOutputArtists.Add(new ArtistWithoutId()
                {
                    Name = artist.artistName,
                    Country = artist.artistCountry,
                    Aliases = aliases
                });
            }

            // Pageination
            int tempPageNumber = pageNumber;
            int maxNumPage = outputArtists.Count / pageSize;
            maxNumPage = outputArtists.Count % pageSize > 0 ? maxNumPage + 1 : maxNumPage;            

            List<ArtistWithoutId> artistsInThePage = formatedOutputArtists
                .Skip(pageSize *  (pageNumber-1 < 0 ? 0 : (pageNumber -1)))
                .Take(pageSize).ToList();

            SearchArtists searchResultArtist = new SearchArtists()
            {
                Results = artistsInThePage,
                NumberOfSearchResults = outputArtists.Count,
                Page = tempPageNumber > maxNumPage ? maxNumPage : tempPageNumber,
                NumberOfPages = maxNumPage,
                PageSize = pageSize
            };
            
            return searchResultArtist;
        }

        public List<Release> SearchReleases(string artistId)
        {
            Artist artist = db.Artist.Find(artistId);
            List<Release> releases = new List<Release>();
            bool isIdInReleases = false;

            if (artist != null)
            {
                string musicBrainzApiReleases = string.Format(@"https://localhost:44355/api/musicbrainz/getreleases/{0}", artistId);
                var webClient = new WebClient();
                webClient.Headers.Add("user-agent", "Only a test!");
                string releasesFromMB = webClient.DownloadString(musicBrainzApiReleases);

                releases = JsonConvert.DeserializeObject<List<Release>>(releasesFromMB);

                foreach (Release release in releases)
                {
                    foreach (ArtistWithIdAndNameOnly otherArtist in release.OtherArtists)
                    {
                        if (otherArtist.Id == artistId)
                        {
                            isIdInReleases = true;
                            break;
                        }
                    }
                    if (isIdInReleases) break;
                }
            }

            return isIdInReleases ? releases : new List<Release>();
        }

        public Album[] SearchAlbums(string artistId)
        {
            string musicBrainzApiAlbums = string.Format(@"https://localhost:44355/api/musicbrainz/getalbums/{0}", artistId);
            var webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Only a test!");
            string albumsFromMB = webClient.DownloadString(musicBrainzApiAlbums);

            List<Album> albums = new List<Album>();
            albums = JsonConvert.DeserializeObject<List<Album>>(albumsFromMB);
            return albums.Take(10).ToArray();
        }
    }
}