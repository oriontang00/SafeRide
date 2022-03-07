using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Models;
using System.Net.Http.Headers;
using System.Security.Claims;
using SafeRide.src.Interfaces;
using SafeRide.src.Security.Interfaces;

namespace SafeRide.src.Services
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;

        private readonly IOTPService otpService;
        private string generatedToken = null;

        private readonly string SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
        private readonly string ISSUER = "www.saferide.net";

        public AuthController(ITokenService tokenService, IOTPService otpService, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
            this.otpService = otpService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserSecurityModel user)
        {
            IActionResult response = Unauthorized();
            var valid = true;
            UserSecurityModel validUser = null;
            try
            {
                validUser = this.userRepository.GetUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                valid = false;
            }

            if (valid && validUser != null)
            {
                generatedToken = tokenService.BuildToken(SECRET_KEY, ISSUER, validUser);

                if (generatedToken != null)
                {
                    response = Ok(new { token = generatedToken });
                }
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("getToken")]
        public IActionResult GetToken([FromHeader] string authorization)
        {
            authorization = authorization.Replace("\"", "");
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(authorization);
                return Ok(new {jsonToken});

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
