using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Models;
using System.Security.Claims;

namespace SafeRide.src.Services
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private string generatedToken = null;

        private readonly string SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
        private readonly string ISSUER = "www.saferide.net";

        public AuthController()
        {
            this.userRepository = new UserRepository();
            this.tokenService = new TokenService();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserSecurityModel user)
        {
            IActionResult response = Unauthorized();
            var validUser = GetUser(user);

            if (validUser != null)
            {
                generatedToken = tokenService.BuildToken(SECRET_KEY, ISSUER, validUser);
                if (generatedToken != null)
                {
                    response = Ok(new { token = generatedToken });
                }
            }

            return response;
        }

        private UserSecurityDTO GetUser(UserSecurityModel user)
        {
            return userRepository.GetUser(user);
        }

    }
}
