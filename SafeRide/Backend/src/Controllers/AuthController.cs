using Backend.Attributes.AuthorizeAttribute;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Models;

namespace SafeRide.src.Services
{
    [Route("api")]
    [Controller]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private string generatedToken = null;

        private readonly string SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
        private readonly string ISSUER = "www.saferide.net";

        public AuthController(ITokenService tokenService, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
        }

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
        
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "admin")]
        [HttpPost]
        [Route("verifyToken")]
        public IActionResult VerifyToken([FromHeader] string authorization)
        {
            authorization = authorization.Replace("Bearer ", "");
            authorization = authorization.Replace("\"", "");
            try
            {
                JwtDecoder.DecodeJwt(authorization);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
