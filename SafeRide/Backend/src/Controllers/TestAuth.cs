using Backend.Attributes.AuthorizeAttribute;
using Microsoft.AspNetCore.Mvc;

namespace SafeRide.Controllers
{
    [Route("api/testing")]
    [ApiController]
    public class TestAuth : ControllerBase
    {
        [HttpGet]
        [Route("get_ok")]
        public IActionResult TestOk()
        {
            return Ok();
        }
        
        [HttpGet]
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "user")]
        [HttpPost]
        [Route("test1")]
        public IActionResult Test1()
        {
            return Ok();
        }
        
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "admin")]
        [HttpPost]
        [Route("test2")]
        public IActionResult Test2()
        {
            return Ok();
        }

        [AuthorizeAttribute.ClaimRequirementAttribute("active", "active")]
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "user")]
        [HttpPost]
        [Route("test3")]
        public IActionResult Test3()
        {
            return Ok();
        }
        
        [AuthorizeAttribute.ClaimRequirementAttribute("role", "test")]
        [HttpPost]
        [Route("test4")]
        public IActionResult Test4()
        {
            return Ok();
        }
    }
}
