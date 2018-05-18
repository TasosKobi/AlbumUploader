using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IPhotoRepository : IRepositoryBase<Photo>
    {
        IEnumerable<Photo>  GetPhotosByUser(int userid);
        IEnumerable<Photo> GetPhotosByPlace(int placeid);
        Photo CreatePhoto(Photo photo, int userid);
        Photo getPhoto(int id);

    }
}
