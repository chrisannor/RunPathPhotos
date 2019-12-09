using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunPath.Models;

namespace RunPath.Helpers
{
    public static class RunPathPhotoEnumerableHelper
    {
        public static List<Album> FilterAlbumsByUserId(this IEnumerable<Album> apiAlbum,
            int? userid = null)
        {
            if (!userid.HasValue) return apiAlbum.ToList();

            return apiAlbum.Where(x => x.UserId == userid).ToList();
        }

        public static List<Photo> FilterPhotosByAlbums(this IEnumerable<Photo> photos, IEnumerable<Album> albums)
        {
            return photos.Where(x => albums.Any(a => a.Id == x.AlbumId)).ToList();
        }

        public static Dictionary<int, List<Photo>> PhotosToAlbumDictionary(this IEnumerable<Photo> photos)
        {
            return photos.GroupBy(x => x.AlbumId).ToDictionary(x => x.Key, x => x.ToList());
        }
    }
}