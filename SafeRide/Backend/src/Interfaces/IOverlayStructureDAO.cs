using System.Collections;
using SafeRide.src.Models;

namespace SafeRide.src.Interfaces;

public interface IOverlayStructureDAO
{
    public OverlayStructureModel GetOverlay(string name);
}