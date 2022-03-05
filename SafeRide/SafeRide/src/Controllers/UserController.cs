﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.DataAccess;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private string generatedToken = null;
        private IUserSecurityDAO _userSecurityDao;

        private readonly string SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
        private readonly string ISSUER = "www.saferide.net";

        public UserController(IUserSecurityDAO userSecurityDao)
        {
            _userSecurityDao = userSecurityDao;
            this.tokenService = new TokenService();
        }
        [Route("createUser")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser([FromBody] UserSecurityModel user)
        {
            user.Role = "user";
            user.Valid = true;
            
            IActionResult response = BadRequest();
            if (_userSecurityDao.Create(user))
            {
                response = Ok();
            }

            return response;
        }
        /*[Route("getUser")]
        [HttpGet]
        public IActionResult GetUser([FromBody] string token, [FromBody] string userId)
        {
            UserModel thisUser = userDAO.Read(userId);

            IActionResult response = Unauthorized();

            if (this.tokenService.IsTokenValid(SECRET_KEY, ISSUER, token)) return Ok(new {  });


            return response;
        }*/
    }
}