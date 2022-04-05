namespace SafeRide.src.Models;

public class OverlayPoint
{
    public float LatPoint { get; set; } 
    public float LongPoint { get; set; }

    public OverlayPoint(float latPoint, float longPoint)
    {
        LatPoint = latPoint;
        LongPoint = longPoint;
    }
}