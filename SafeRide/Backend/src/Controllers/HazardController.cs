using System.Text.RegularExpressions;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using AuthorizeAttribute = Backend.Attributes.AuthorizeAttribute.AuthorizeAttribute;

namespace SafeRide.Controllers
{
    // [Microsoft.AspNetCore.Mvc.Route("api")]
    // [Controller]
    // [ApiController]
    public class HazardController : ControllerBase
    {
        private readonly ApplicationUser _user;
        private readonly Route _route;
        private readonly IHazardExclusionService _hazardExclusionService;
        //private readonly IHazardReportingService _hazardReportingService;
                
        // [Microsoft.AspNetCore.Mvc.Route("excludeHazard")]
        // [Microsoft.AspNetCore.Mvc.HttpPost]
        public HazardController(ApplicationUser user, Route route) {
            this._user = _user;
            this._route = route; 
            this._hazardExclusionService = new HazardExclusionService(route);
        }
        // [HttpGet]
        // [Route("exclude")]
        public bool Exclude(List<HazardType> hazards) {
            _hazardExclusionService.FindHazardsNearRoute(hazards);
        }




    }
}