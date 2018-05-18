using Contracts;
using Entities.Models;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoService
{
    public class PhotoManager : IPhotoManager
    {
        private IRepositoryWrapper _repository;
        private IHostingEnvironment _hostingEnvironment;

        public PhotoManager(IRepositoryWrapper repository, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task SavePhoto(IFormFile file, int userid)
        {
            //Constructing the photo Entity to save in Database
            Photo photo = new Photo
            {
                UserId = userid,
                AddedDate = DateTime.Today
            };

            //Saving the photo in Database
            _repository.Photo.Create(photo);
            _repository.Photo.Save();

            //Creating the Path and the Directory in Server File System for the current user
            var id = Path.Combine(_hostingEnvironment.WebRootPath, photo.UserId.ToString());
            var filePath = Path.Combine(id, file.FileName);
            System.IO.Directory.CreateDirectory(id);

            //Saving the Photo in the file system
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Close();

                //Using the MetaDataExtractor Library to get the coordinates of the Photo
                Image image = new Bitmap(filePath);
                var gps = ImageMetadataReader.ReadMetadata(filePath)
                                 .OfType<GpsDirectory>()
                                 .FirstOrDefault();
                var location = gps.GetGeoLocation();

                photo.Path = filePath;
                photo.latitude = location.Latitude;
                photo.longitude = location.Longitude;

                //Saving the coordinates and Photo path in Photo Table
                _repository.Photo.Update(photo);
                _repository.Photo.Save();
            }
        }

        public IEnumerable<Photo> GetPhotos(int userid)
        {
            return _repository.Photo.GetPhotosByUser(userid);
        }
        public Photo GetPhoto(int photoid)
        {
            return _repository.Photo.getPhoto(photoid);
        }
    }
}
