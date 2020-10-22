using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIArtist.Models
{
    public class ArtistResult
    {
        public List<ArtistInfo> Results { get; set; }
        public int NumberOfSearchResults { get; set; }
        public int Page { get; set; }
        public int NumberOfPages { get; set; }
    }
}