using System.Collections;

namespace SafeRide.src.Models;

public class OverlayStructureModel
{
    private string _overlayName;
    private List<OverlayPoint> _overlayStructure;

    public OverlayStructureModel(string overlayName)
    {
        _overlayName = overlayName;
    }

    public void SetStructure(List<OverlayPoint> overlayStructure)
    {
        _overlayStructure = overlayStructure;
    }
}