using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IViewEventDAO
    {
        Dictionary<string, int> GetTopFiveViews();
        Dictionary<string, double> GetTopFiveDurations();
        int CreateViewEvent(ViewEvent viewEvent); 
    }
}
