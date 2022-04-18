using System.Collections;

namespace SafeRide.src.Models;

public class OverlayStructureModel
{
    private string _overlayName;
    public List<OverlayPoint> _overlayStructure { get; set; }
    public string overlayColor { get; set; }

    public OverlayStructureModel(string overlayName)
    {
        _overlayName = overlayName;
    }

    public void SetStructure(List<OverlayPoint> overlayStructure)
    {
        _overlayStructure = overlayStructure;
    }
}