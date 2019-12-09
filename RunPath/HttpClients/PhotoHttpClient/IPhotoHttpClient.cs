using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RunPath.Models;

namespace RunPath.HttpClients
{
    using Refit;

    public interface IPhotoHttpClient
    {
        
        [Get("/albums")]
        Task<IEnumerable<Album>> GetAlbums();

        [Get("/photos")]
        Task<IEnumerable<Photo>> GetPhotos();
    }
}