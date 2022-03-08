using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IAnalyticsService
    {
        public Dictionary<string, int> GetLastThreeMonthLogins();
        public Dictionary<string, int> GetLastThreeMonthRegistrations();
        public Dictionary<string, int> GetTopFiveViews();
        public Dictionary<string, double> GetTopFiveDurations();
        public int CreateViewEvent(ViewEvent viewEvent);
    }
}
