using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhotosProject.Controllers
{
    [Produces("application/json")]
    [Route("api/Album")]
    [EnableCors("MyPolicy")]
    public class AlbumController : Controller
    {
        private IRepositoryWrapper _repository;

        public AlbumController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getalbums")]
        public IActionResult UserAlbums(int id)
        {
            try
            {
                return Ok(_repository.Album.GetAllAlbums(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }
        [HttpGet]
        [Produces("application/json")]
        [Route("getalbumphotos")]
        public IActionResult AlbumPhotos(int albumid)
        {
            try
            {
                return Ok(_repository.AlbumPhotos.GetAllReferences(albumid));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        [Route("createalbum")]
        public IActionResult Register([FromBody] Album album)
        {
            try
            {
                if (_repository.Album.Exists(album.Name))
                {
                    return BadRequest();
                }
                album = _repository.Album.CreateAlbum(album);

                return Ok(album);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("addPhoto")]
        public IActionResult AddPhoto([FromBody] AlbumPhotos albumPhotos)
        {
            try
            {
                if (_repository.AlbumPhotos.Exists(albumPhotos.PhotoId))
                {
                    return BadRequest();
                }
                albumPhotos = _repository.AlbumPhotos.AddPhoto(albumPhotos);

                return Ok(albumPhotos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }
    }
}
