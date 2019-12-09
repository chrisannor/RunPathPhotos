using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RunPath.Models;
using RunPath.HttpClients;
using System.Linq;

namespace RunPath.Services
{
    public interface IPhotoService
    {
        Task<RunPathApiResponse<IEnumerable<RunPathAlbum>>> GetRunPathPhotos(int? userId = null);
    }
}