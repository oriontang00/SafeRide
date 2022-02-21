/*using Microsoft.AspNetCore.Mvc;
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
        private IUserDAO userDAO = new UserSQLServerDAO();

        private readonly string SECRET_KEY = "this is my custom Secret key for authnetication"; //needs many characters
        private readonly string ISSUER = "www.saferide.net";

        public UserController()
        {
            this.tokenService = new TokenService();
        }
        [Route("createUser")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            IActionResult response = Unauthorized();
            userDAO.Create(user);

            return response;
        }
        [Route("getUser")]
        [HttpGet]
        public IActionResult GetUser([FromBody] string token, [FromBody] string userId)
        {
            UserModel thisUser = userDAO.Read(userId);

            IActionResult response = Unauthorized();

            if (this.tokenService.IsTokenValid(SECRET_KEY, ISSUER, token)) return Ok(new {  });


            return response;
        }
    }
}
*/