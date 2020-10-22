using APIArtist.Models;
using APIArtist.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIArtist.Controllers
{
    public class ArtistController : ApiController
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        //Get All artists from database
        //eg: https://localhost:44304/artists

        [Route("artists")]
        public IQueryable<Artist> GetArtists()
        {
            return _artistService.GetArtists();
        }

        //Get artist By ID
        //eg: https://localhost:44304/artist/6456a893-c1e9-4e3d-86f7-0008b0a3ac8a

        [Route("artist/{artistId}")]
        public Artist GetArtistById(Guid artistId)
        {
            return _artistService.GetArtistById(artistId);
        }

        //search artist by criteria
        //eg:https://localhost:44304/artist/search/tra

        [Route("artist/search/{search}/{page:int?}/{pageSize:int?}")]
        [HttpGet]
        public ArtistResult SearchArtist(string search, int page = 1, int pageSize = 10)
        {
            return _artistService.SearchArtist(search, page, pageSize);
        }

        //get Top 10 albums of an artist
        //eg: https://localhost:44304/artist/f82f3a3e-29c2-42ca-b589-bc5dc210fa9e/albums

        [Route("artist/{artistId}/albums")]
        [HttpGet]
        public List<Albums> GetTopAlbums(Guid artistId)
        {
            return _artistService.GetTopAlbums(artistId);
        }

        //get Top 100 releases of an artist
        //eg: https://localhost:44304/artist/c44e9c22-ef82-4a77-9bcd-af6c958446d6/releases

        [Route("artist/{artistId}/releases")]
        [HttpGet]
        public List<Releases> GetReleases(Guid artistId)
        {
            return _artistService.GetReleases(artistId);
        }
    }
}
