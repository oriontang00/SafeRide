using System.Web.Http;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;

namespace Backend.Controllers;

[ApiController]
public class FeatureController : ControllerBase
{
    private IOverlayStructureDAO _overlayStructureDao;
    
    public FeatureController(IOverlayStructureDAO overlayStructureDao)
    {
        _overlayStructureDao = overlayStructureDao;
    }

    [Microsoft.AspNetCore.Mvc.HttpGet]
    [Microsoft.AspNetCore.Mvc.Route("/api/overlay/all")]
    public IActionResult GetAvailableOverlays([FromHeader] string authorization)
    {
        return Ok();
    }
    
    [Microsoft.AspNetCore.Mvc.HttpGet]
    [Microsoft.AspNetCore.Mvc.Route("/api/overlay/dim")]
    public IActionResult GetGeometryInfo([FromHeader] string authorization, [FromUri] string overlayName)
    {
        var user = JwtDecoder.GetUser(authorization);
        if (user == null) return Unauthorized();
        
        return Ok(new {_overlayStructureDao.GetOverlay(user, overlayName)._overlayStructure});
    }
}