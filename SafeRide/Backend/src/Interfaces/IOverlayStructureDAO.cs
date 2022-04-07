using System.Collections;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces;

public interface IOverlayStructureDAO
{
    public OverlayStructureModel GetOverlay(string userName, string overlayName);
    public List<string> GetAvailableOverlays(string userName);
}