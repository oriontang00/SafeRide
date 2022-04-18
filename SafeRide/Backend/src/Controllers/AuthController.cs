using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Models;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http;
using SafeRide.src.Interfaces;
using SafeRide.src.Security.Interfaces;
using AuthorizeAttribute = Backend.Attributes.AuthorizeAttribute.AuthorizeAttribute;

namespace SafeRide.src.Services
{
    [Microsoft.AspNetCore.Mvc.Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;

        private readonly IOTPService otpService;
        
        private string generatedToken = null;

        private readonly string SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
        private readonly string ISSUER = "www.saferide.net";

        public AuthController(ITokenService tokenService, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
            //this.otpService = otpService;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public IActionResult Login([Microsoft.AspNetCore.Mvc.FromBody] UserSecurityModel user)
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
                //promt user on frontend to input their otp
                /*otpService.SetUser(validUser);*/
                try
                {
                    generatedToken = tokenService.BuildToken(SECRET_KEY, ISSUER, validUser);

                    if (generatedToken != null)
                    {
                        response = Ok(new { token = generatedToken });
                    }
                }
                catch (Exception ex)
                {
                    response = Unauthorized();
                }

            }

            return response;
        }
        
        
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("otp")]
        public IActionResult Validate([Microsoft.AspNetCore.Mvc.FromBody] UserSecurityModel user, [FromUri] string providedOTP)
        {
            IActionResult response = Unauthorized();
            //otpService = new OTPService(validUser);
            UserSecurityModel validUser = null;

            try
            {
                validUser = this.userRepository.GetUser(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }
        
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "admin")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("verifyToken")]
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
