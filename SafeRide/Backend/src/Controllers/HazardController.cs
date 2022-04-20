using System.Text.RegularExpressions;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.Controllers
{
    // [Microsoft.AspNetCore.Mvc.Route("api")]
    // [Controller]
    // [ApiController]
    public class HazardController : ControllerBase
    {
        private readonly ApplicationUser _user;
        private readonly MapRoute _route;
        private readonly IHazardExclusionService _hazardExclusionService;
        private readonly IParseResponseService _parseResponseService;
                

        public HazardController(ApplicationUser user, string jsonResponse) {
            this._user = _user;
            this._parseResponseService = new ParseResponseService(jsonResponse);
            this._route = _parseResponseService.ParseFirstRoute();
            this._hazardExclusionService = new HazardExclusionService(_route);
        }
        
        /* 
        on frontend: 
        Ajax.BeginForm("Exclude", 
                            new AjaxOptions { UpdateTargetId = "divHazards" }))
       
        [HttpGet]
        [Route("exclude")] 
        */
        public bool Exclude(List<int> hazards) {
            Dictionary<double, double>  coordinates = this._parseResponseService.ParseStepCoordinates();

            _hazardExclusionService.FindHazardsNearRoute(hazards);
        }
        
  
        
         
        [HttpPost]
        [Route("exclude")]
        public bool Report(List<int> hazards) {
            _hazardExclusionService.FindHazardsNearRoute(hazards);
        }






    }
}