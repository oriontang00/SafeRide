using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;

namespace SafeRide.src.Controllers
{
    [Route("api/analytics")]
    [ApiController]
    [Produces("application/json")]
    public class AnalyticsController : ControllerBase
    {
 
        private IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            this._analyticsService =  analyticsService;
        }

        [HttpGet]
        [Route("topViews")]
        public IActionResult TopViews()
        {
            return Ok(this._analyticsService.GetTopFiveViews());
        }

        [HttpGet]
        [Route("topDurations")]
        public IActionResult TopDurations()
        {
            return Ok(this._analyticsService.GetTopFiveDurations());
        }

        [HttpGet]
        [Route("lastThreeMonthLogins")]
        public IActionResult LastThreeMonthLogins()
        {
            return Ok(this._analyticsService.GetLastThreeMonthLogins());
        }

        [HttpGet]
        [Route("lastThreeMonthRegistrations")]
        public IActionResult LastThreeMonthRegistrations()
        {
            return Ok(this._analyticsService.GetLastThreeMonthRegistrations());
        }
    }
}
