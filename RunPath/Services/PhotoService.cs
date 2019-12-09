using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RunPath.Models;
using RunPath.HttpClients;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using RunPath.Helpers;

namespace RunPath.Services
{
    public class PhotoService : IPhotoService
    {

        private readonly IPhotoHttpClient _photoHttpClient;

        public PhotoService(IPhotoHttpClient photoHttpClient)
        {
            _photoHttpClient = photoHttpClient;
        }

        public async Task<RunPathApiResponse<IEnumerable<RunPathAlbum>>> GetRunPathPhotos(int? userId = null)
        {
            try
            {
                var albums = _photoHttpClient.GetAlbums();
                var photos = _photoHttpClient.GetPhotos();

                await Task.WhenAll(albums);//, photos);

                var userAlbums = albums.Result.FilterAlbumsByUserId(userId);
                var userPhotos = photos.Result.FilterPhotosByAlbums(userAlbums);
                var albumDictionary = userPhotos.PhotosToAlbumDictionary();

                return new RunPathApiResponse<IEnumerable<RunPathAlbum>>(userAlbums.Select(
                    album => new RunPathAlbum(album, albumDictionary)).ToList());
            }
            catch (WebException e)
            {
                return new RunPathApiResponse<IEnumerable<RunPathAlbum>>($"An exception occured: {e}");
            }
            catch (SocketException e)
            {
                return new RunPathApiResponse<IEnumerable<RunPathAlbum>>($"An error occured while getting data from endpoint: {e}");
            }
            catch (Exception e)
            {
                return new RunPathApiResponse<IEnumerable<RunPathAlbum>>($"An unkown error occured: {e.Message}");
            }


        }
    }
}