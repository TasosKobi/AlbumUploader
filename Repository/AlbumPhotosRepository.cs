using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AlbumPhotosRepository : RepositoryBase<AlbumPhotos>, IAlbumPhotosRepository
    {
        public AlbumPhotosRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<AlbumPhotos> GetAllReferences(int albumid)
        {
            return FindByCondition(a => a.AlbumId.Equals(albumid));
        }

        public AlbumPhotos AddPhoto(AlbumPhotos albumPhotos)
        {
            Create(albumPhotos);
            Save();
            return albumPhotos;
            
        }

        public bool Exists(int photoId)
        {
            var albumPhotos = FindByPhotoId(photoId);

            if (albumPhotos.PhotoId != 0)
            {
                return true;
            }
            return false;
        }

        public AlbumPhotos FindByPhotoId(int photoid)
        {
            return FindByCondition(x => x.PhotoId.Equals(photoid)).FirstOrDefault<AlbumPhotos>();
        }
    }
}

