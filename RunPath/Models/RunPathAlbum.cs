using System;
using RunPath.HttpClients;
using System.Collections.Generic;

namespace RunPath.Models
{
    public class RunPathAlbum : Album
    {
        public RunPathAlbum(Album album, IDictionary<int,List<Photo>> dictionary)
        {
            Id = album.Id;
            UserId = album.UserId;
            Title = album.Title;
            Photos = SetAlbumPhotos(dictionary);
        }
        public IEnumerable<Photo> Photos { get; set; }

        public IEnumerable<Photo> SetAlbumPhotos(IDictionary<int, List<Photo>> albumDictionary)
        {
            albumDictionary.TryGetValue(Id, out var result);
            return result;
        }
    }
}