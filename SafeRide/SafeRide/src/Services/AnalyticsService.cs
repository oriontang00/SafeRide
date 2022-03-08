using SafeRide.src.Interfaces;
using SafeRide.src.Models;

namespace SafeRide.src.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private IUserDAO _userDAO;
        private IViewEventDAO _viewEventDAO;

        public AnalyticsService(IUserDAO userDAO, IViewEventDAO viewEventDAO)
        {
            this._userDAO = userDAO;
            this._viewEventDAO = viewEventDAO;
        }
        
        public int CreateViewEvent(ViewEvent viewEvent)
        {
            return _viewEventDAO.CreateViewEvent(viewEvent);
        }

        public Dictionary<string, int> GetLastThreeMonthLogins()
        {
            return  _userDAO.GetLastThreeMonthLogins();
        }

        public Dictionary<string, int> GetLastThreeMonthRegistrations()
        {
            return _userDAO.GetLastThreeMonthRegistrations();
        }

        public Dictionary<string, double> GetTopFiveDurations()
        {
            return _viewEventDAO.GetTopFiveDurations();
        }

        public Dictionary<string, int> GetTopFiveViews()
        {
            return _viewEventDAO.GetTopFiveViews();
        }
    }
}
