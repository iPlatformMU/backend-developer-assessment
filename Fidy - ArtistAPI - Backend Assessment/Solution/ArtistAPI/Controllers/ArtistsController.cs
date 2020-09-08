using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ArtistAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ArtistAPI.Services;

namespace ArtistAPI.Controllers
{
    public class ArtistsController : ApiController
    {
        //private DB_ArtistsEntities db = new DB_ArtistsEntities();
        private readonly IGetArtistSvc _getArtist;

        public ArtistsController (IGetArtistSvc getArtist)
        {
            this._getArtist = getArtist;
        }

        // GET: api/artists
        public IQueryable<Artist> GetArtist()
        {
            return this._getArtist.GetArtists();
        }

        // GET: api/artists/5
        [ResponseType(typeof(Artist))]
        public Artist GetArtist(string id)
        {
            return this._getArtist.GetArtist(id);
        }

        // GET: api/artists/search/<search_criteria>/<page_number>/<page_size>
        [Route("api/artists/search/{criteria}/{pageNumber:int?}/{pageSize:int?}")]
        [HttpGet]
        public SearchArtists SearchArtist(string criteria, int pageNumber = 1, int pageSize = 10)
        {
            return this._getArtist.GetArtistsByCriteria(criteria, pageNumber, pageSize);
        }


        // GET: api/artists/<artist_id>/releases
        [Route("api/artists/{artistId}/releases")]
        [HttpGet]
        public List<Release> SearchReleases (string artistId)
        {
            return this._getArtist.SearchReleases(artistId);
        }

        // GET: api/artists/<artist_id>/albums
        [Route("api/artists/{artistId}/albums")]
        [HttpGet]
        public Album[] SearchAlbums(string artistId)
        {
            return this._getArtist.SearchAlbums(artistId);
        }
    }
}