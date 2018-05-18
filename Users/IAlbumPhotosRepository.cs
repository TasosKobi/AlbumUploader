using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IAlbumPhotosRepository : IRepositoryBase<AlbumPhotos>
    {
        IEnumerable<AlbumPhotos> GetAllReferences(int albumid);
        AlbumPhotos  AddPhoto(AlbumPhotos albumPhotos);
        bool Exists(int photoId);
        AlbumPhotos FindByPhotoId(int photoid);
    }
}
