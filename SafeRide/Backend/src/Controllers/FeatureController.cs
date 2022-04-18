using System.Web.Http;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using AuthorizeAttribute = Backend.Attributes.AuthorizeAttribute.AuthorizeAttribute;

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
        var user = JwtDecoder.GetUser(authorization);
        if (user == null) return Unauthorized();

        var overlays = _overlayStructureDao.GetAvailableOverlays(user);
        
        return Ok(new {overlays});
    }
    
    [Microsoft.AspNetCore.Mvc.HttpGet]
    [Microsoft.AspNetCore.Mvc.Route("/api/overlay/dim")]
    public IActionResult GetGeometryInfo([FromHeader] string authorization, [FromUri] string overlayName)
    {
        var user = JwtDecoder.GetUser(authorization);
        if (user == null) return Unauthorized();

        var readStructure = _overlayStructureDao.GetOverlay(user, overlayName);
        var overlayStructure = readStructure._overlayStructure;
        var overlayColor = readStructure.overlayColor;
        
        return Ok(new {overlayStructure, overlayColor});
    }

    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.Route("/api/overlay/addPoint")]
    public IActionResult AddPointToOverlay([FromHeader] string authorization, [Microsoft.AspNetCore.Mvc.FromBody] OverlayPoint newPoint, [FromUri] string overlayName)
    {
        var user = JwtDecoder.GetUser(authorization);
        if (user == null) return Unauthorized();

        try
        {
            if (_overlayStructureDao.AddOverlayPoint(user, overlayName, newPoint))
            {
                return Ok();
            }
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return BadRequest();
    }
    
    [Microsoft.AspNetCore.Mvc.HttpPost]
    [Microsoft.AspNetCore.Mvc.Route("/api/overlay/removePoint")]
    public IActionResult RemovePointFromOverlay([FromHeader] string authorization, [Microsoft.AspNetCore.Mvc.FromBody] OverlayPoint oldPoint, [FromUri] string overlayName)
    {
        var user = JwtDecoder.GetUser(authorization);
        if (user == null) return Unauthorized();

        try
        {
            if (_overlayStructureDao.RemoveOverlayPoint(user, overlayName, oldPoint))
            {
                return Ok();
            }
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return BadRequest();
    }
}