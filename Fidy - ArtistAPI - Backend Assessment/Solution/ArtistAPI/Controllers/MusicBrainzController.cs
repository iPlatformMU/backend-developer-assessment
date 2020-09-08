using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ArtistAPI.Models;
using ArtistAPI.Services;

namespace ArtistAPI.Controllers
{
    public class MusicBrainzController : ApiController
    {
        private readonly ISearchMusicBrainzReleaseSvc _searchMusicBrainzReleaseSvc;

        public MusicBrainzController(ISearchMusicBrainzReleaseSvc searchMusicBrainzReleaseSvc)
        {
            this._searchMusicBrainzReleaseSvc = searchMusicBrainzReleaseSvc;
        }

        // GET: api/MusicBrainz/GetReleases/<artist_id>
        [Route("api/musicbrainz/getreleases/{artistId}")]
        public List<Release> GetReleasesByMusicBrainz(string artistId)
        {
            return this._searchMusicBrainzReleaseSvc.GetReleaseByMusicBrainz(artistId);
        }

        // GET: api/MusicBrainz/getalbums/<artist_id>
        [Route("api/musicbrainz/getalbums/{artist_id}")]
        public List<Album> GetAlbumsByMusicBrainz(string artist_id)
        {
            return this._searchMusicBrainzReleaseSvc.GetAlbumsByMusicBrainz(artist_id);
        }
    }
}
