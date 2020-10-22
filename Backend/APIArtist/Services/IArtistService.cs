using APIArtist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIArtist.Services
{
    public interface IGetArtists
    {
        IQueryable<Artist> GetArtists();
    }

    public interface IGetArtistById
    {
        Artist GetArtistById(Guid id);
    }

    public interface ISearchArtist
    {
        ArtistResult SearchArtist(string criteria, int page, int pageSize);
    }

    public interface IGetTopAlbums
    {
        List<Albums> GetTopAlbums(Guid id);
    }

    public interface IGetReleases
    {
        List<Releases> GetReleases(Guid id);
    }
    public interface IArtistService: IGetArtists, IGetArtistById, ISearchArtist, IGetTopAlbums, IGetReleases
    {
    }
}
