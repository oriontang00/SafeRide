using System.Text.RegularExpressions;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using AuthorizeAttribute = Backend.Attributes.AuthorizeAttribute.AuthorizeAttribute;

namespace SafeRide.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api")]
    [Controller]
    [ApiController]
    public class HazardController : ControllerBase
    {
        private readonly IUserRepository _user;
        private readonly Route _route;
        private readonly IHazardExclusionService _hazardExclusionService;
                
        [Microsoft.AspNetCore.Mvc.Route("excludeHazard")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public HazardController(IUserRepository user, Route route) {
            this._user = _user;
            this._route = route; 
        }




    }
}