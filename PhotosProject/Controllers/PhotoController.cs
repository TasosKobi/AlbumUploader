using System;
using Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PhotosProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Photo")]
    [EnableCors("MyPolicy")]
    public class PhotoController : Controller
    {

        private IRepositoryWrapper _repository;
        private IPhotoManager _photoManager;

        public PhotoController(IRepositoryWrapper repository, IPhotoManager photoManager)
        {
            _repository = repository;
            _photoManager = photoManager;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getphotos")]
        public IActionResult UserPhotos( int id)
        {
            try
            {
                return Ok(_photoManager.GetPhotos(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getphoto")]
        public IActionResult GetPhoto(int id)
        {
            try
            {
                return Ok(_photoManager.GetPhoto(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        [HttpPost]
        [EnableCors("MyPolicy")]
        [Route("upload")]
        public ActionResult UploadFile(IFormFile file,[FromQuery]int userid)
        {
            try
            {
                _photoManager.SavePhoto(file, userid);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }
    }
}