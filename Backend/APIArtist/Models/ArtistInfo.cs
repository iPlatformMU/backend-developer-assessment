using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIArtist.Models
{
    public class ArtistInfo
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string[]? Alias { get; set; }
    }
}