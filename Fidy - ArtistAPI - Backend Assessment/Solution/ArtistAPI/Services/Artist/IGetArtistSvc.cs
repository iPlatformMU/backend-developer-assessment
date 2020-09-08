using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtistAPI.Models;

namespace ArtistAPI.Services
{
    public interface IGetArtistSvc: IGetArtists, IGetArtistById, IGetArtistsByCriteria, ISearchRelease, ISearchAlbumsByArtistId
    {
    }
}
