using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtistAPI.Models;

namespace ArtistAPI.Services
{
    public interface IGetArtistsByCriteria
    {
        SearchArtists GetArtistsByCriteria(string criteria, int pageNumber, int pageSize);
    }
}
