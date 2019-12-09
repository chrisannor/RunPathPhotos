using System.Collections.Generic;
using Moq;
using RunPath.HttpClients;
using RunPath.Services;
using Xunit;
using System.Threading.Tasks;
using RunPath.Models;
using System.Linq;
using Castle.Core.Internal;

namespace RunPathTests
{


    public class RunPathApiMust
    {
        private readonly IPhotoService _photoservice;

        private readonly Mock<IPhotoHttpClient> _photoHttpClient;

        private readonly PhotoTestData _photos;
        private readonly AlbumTestData _albums;

        public RunPathApiMust()
        {
            _photoHttpClient = new Mock<IPhotoHttpClient>();
            _photoservice = new PhotoService(_photoHttpClient.Object);

            _photos = new PhotoTestData();
            _albums = new AlbumTestData();


            _photoHttpClient.Setup(x => x.GetAlbums()).ReturnsAsync(_albums.GetAlbums).Verifiable();
            _photoHttpClient.Setup(x => x.GetPhotos()).ReturnsAsync(_photos.GetPhotos).Verifiable();
        }

        [Fact]
        public async Task call_both_http_methods_to_get_photos_and_albums()
        {

            await _photoservice.GetRunPathPhotos();

            // assert
            _photoHttpClient.Verify(x => x.GetAlbums());
            _photoHttpClient.Verify(x => x.GetPhotos());

        }

        [Fact]
        public async Task return_all_photos_and_albums_when_no_id_is_entered()
        {
            var result = await _photoservice.GetRunPathPhotos();


            int actualPhotosCount = 0;
            result.Response.ToList().ForEach(x => actualPhotosCount += !x.Photos.IsNullOrEmpty() ? x.Photos.Count() : 0);

            Assert.Equal(_albums.NumberOfAlbums(), result.Response.Count());
            Assert.Equal(_photos.GetPhotoCount(), actualPhotosCount);
        }

        [Fact]
        public async Task return_only_photos_for_given_user_id()
        {
            var userId = 1;
            var result = await _photoservice.GetRunPathPhotos(userId);

            foreach (var album in result.Response)
            {
                Assert.Equal(userId, album.UserId);
            }
        }

        [Fact]
        public async Task correctly_insert_photos_into_correct_album_using_album_id()
        {
            var result = await _photoservice.GetRunPathPhotos();

            foreach (var album in result.Response)
            {
                if(album.Photos.IsNullOrEmpty()) continue;
                foreach (var photo in album.Photos)
                {
                    Assert.Equal(album.Id, photo.AlbumId);

                }
            }
        }
    }

}