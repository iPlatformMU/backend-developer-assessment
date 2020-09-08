using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtistAPI.Models;
using ArtistAPI.Services.MusicBrainz;

namespace ArtistAPI.Services
{
    public interface ISearchMusicBrainzReleaseSvc: IGetReleaseByMusicBrainz, IGetAlbumsByMusicBrainz
    {
    }
}
