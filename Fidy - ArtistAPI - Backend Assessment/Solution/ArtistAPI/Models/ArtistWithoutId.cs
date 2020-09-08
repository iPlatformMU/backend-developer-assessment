using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistAPI.Models
{
    public class ArtistWithoutId
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string[] Aliases { get; set; }
    }
}