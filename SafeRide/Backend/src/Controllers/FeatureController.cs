using Microsoft.AspNetCore.Mvc;
using SafeRide.src.Interfaces;

namespace Backend.Controllers;

[Microsoft.AspNetCore.Mvc.Route("overlay")]
[ApiController]
public class FeatureController : ControllerBase
{
    private IOverlayStructureDAO _overlayStructureDao;
    
    public FeatureController(IOverlayStructureDAO overlayStructureDao)
    {
        _overlayStructureDao = overlayStructureDao;
    }
    
    [HttpGet]
    public IActionResult GetGeometryInfo()
    {
        
        return Ok();
    }
}