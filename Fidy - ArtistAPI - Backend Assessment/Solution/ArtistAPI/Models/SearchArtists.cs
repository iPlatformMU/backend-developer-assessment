using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistAPI.Models
{
    public class SearchArtists
    {
        public List<ArtistWithoutId> Results { get; set; }
        public int NumberOfSearchResults { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int NumberOfPages { get; set; }
    }
}