using System;
using Contracts;
using EncryptionService;
using Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace PhotosProject.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private IRepositoryWrapper _repository;
        private IEncryptionManager encryptionManager;
        //private ITokenManager tokenManager;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
            encryptionManager = new EncryptionManager();
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                

                if (!_repository.User.Exists(user.Email))
                {
                    return BadRequest();
                }
                if (!_repository.User.PasswordIsValid(user))
                {
                    return BadRequest();
                }
                user = _repository.User.FindByEmail(user.Email);
                _repository.User.IsLogin(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                if (_repository.User.Exists(user.Email))
                {
                    return BadRequest();
                }
                user = _repository.User.CreateUser(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout([FromBody]User user)
        {
            try
            {
                _repository.User.Logout(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex);
            }
        }
    }
}