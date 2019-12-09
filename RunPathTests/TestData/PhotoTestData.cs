using System.Collections.Generic;
using RunPath.Models;

namespace RunPathTests
{
    public class PhotoTestData
    {

        private readonly List<Photo> _photos;
        private readonly int _photoCount;

        public PhotoTestData()
        {
            _photos = new List<Photo> {
                    new Photo {
                        AlbumId = 1,
                        Id = 1,
                        Title = "accusamus beatae ad facilis cum similique qui sunt",
                        Url = "https://via.placeholder.com/600/92c952",
                        ThumbnailUrl = "https://via.placeholder.com/150/92c952"
                    },
                    new Photo()
                    {
                        AlbumId = 1,
                        Id = 2,
                        Title = "reprehenderit est deserunt velit ipsam",
                        Url = "https://via.placeholder.com/600/771796",
                        ThumbnailUrl = "https://via.placeholder.com/150/771796"
                    },
                    new Photo()
                    {
                        AlbumId = 2,
                        Id = 3,
                        Title = "officia porro iure quia iusto qui ipsa ut modi",
                        Url = "https://via.placeholder.com/600/24f355",
                        ThumbnailUrl = "https://via.placeholder.com/150/24f355"
                    },
                    new Photo()
                    {
                        AlbumId = 2,
                        Id = 4,
                        Title = "culpa odio esse rerum omnis laboriosam voluptate repudiandae",
                        Url = "https://via.placeholder.com/600/d32776",
                        ThumbnailUrl = "https://via.placeholder.com/150/d32776"
                    },
                    new Photo()
                    {
                        AlbumId = 3,
                        Id = 5,
                        Title = "natus nisi omnis corporis facere molestiae rerum in",
                        Url = "https://via.placeholder.com/600/f66b97",
                        ThumbnailUrl = "https://via.placeholder.com/150/f66b97"
                    }
                };
            _photoCount = _photos.Count;
        }

        public List<Photo> GetPhotos() => _photos;
        public int GetPhotoCount() => _photoCount;
    }
}
