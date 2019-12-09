using System.Collections.Generic;
using RunPath.Models;

namespace RunPathTests
{
    public class AlbumTestData
    {
        private readonly List<Album> _albums;
        private readonly int _albumCount;

        public AlbumTestData()
        {
            _albums = new List<Album> {
                new Album {
                    UserId = 1,
                    Id = 1,
                    Title = "quidem molestiae enim"
                },
                new Album {
                    UserId = 1,
                    Id = 2,
                    Title = "sunt qui excepturi placeat culpa"
                },
                new Album {
                    UserId = 1,
                    Id = 3,
                    Title = "omnis laborum odio"
                },
                new Album {
                    UserId = 1,
                    Id = 4,
                    Title = "non esse culpa molestiae omnis sed optio"
                },
                new Album {
                    UserId = 1,
                    Id = 5,
                    Title = "eaque aut omnis a"
                }
            };

            _albumCount = _albums.Count;
        }

        public List<Album> GetAlbums() => _albums;

        public int NumberOfAlbums() => _albumCount;
    }
}
