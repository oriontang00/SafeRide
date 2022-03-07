using Backend.Attributes.AuthorizeAttribute;
using Microsoft.AspNetCore.Mvc;

namespace SafeRide.Controllers
{
    [Route("api/testing")]
    [ApiController]
    public class TestAuth : ControllerBase
    {
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "user")]
        [HttpGet]
        [Route("test1")]
        public IActionResult Test1()
        {
            return Ok();
        }
        
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "admin")]
        [HttpGet]
        [Route("test2")]
        public IActionResult Test2()
        {
            return Ok();
        }

        [HttpGet]
        [Route("test3")]
        public IActionResult Test3()
        {
            return Ok();
        }
        
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "test")]
        [HttpGet]
        [Route("test4")]
        public IActionResult Test4()
        {
            return Ok();
        }
    }
}
