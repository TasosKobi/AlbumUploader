using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class PhotoRepository : RepositoryBase<Photo> , IPhotoRepository
    {
        public PhotoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public Photo getPhoto(int id)
        {
            return FindByCondition(a => a.photoid.Equals(id)).FirstOrDefault<Photo>();
        }
        public IEnumerable<Photo> GetPhotosByUser(int userid)
        {
            return FindByCondition(a => a.UserId.Equals(userid));
        }
        public IEnumerable<Photo> GetPhotosByPlace(int placeid)
        {
            return null;
        }
        public Photo CreatePhoto(Photo photo, int userid)
        {
            photo.UserId = userid;
            Create(photo);
            Save();
            return photo;
        }

    }
}
