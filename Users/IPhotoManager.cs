using Entities.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPhotoManager
    {
        Task SavePhoto(IFormFile file, int userid);
        IEnumerable<Photo> GetPhotos(int userid);
        Photo GetPhoto(int photoid);


    }
}
