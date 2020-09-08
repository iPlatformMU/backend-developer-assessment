using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistAPI.Models
{
    public class CustumRelease
    {
        public string ReleaseId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Label { get; set; }
        public int NumberOfTrack { get; set; }
        public ArtistWithIdAndNameOnly[] MyProperty { get; set; }
    }
}