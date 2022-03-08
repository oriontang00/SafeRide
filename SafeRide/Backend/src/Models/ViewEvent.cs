namespace SafeRide.src.Models
{
    public class ViewEvent
    {
        private string _userId;
        public string UserId { get { return _userId; } }
       
        private string _viewURL;
        public string ViewURL { get { return _viewURL; } }

        private DateTime _startDate;
        public DateTime StartDate { get { return _startDate; } }

        private DateTime _endDate;
        public DateTime EndDate { get { return _endDate; } }

        private double _elapsedSeconds;
        public double ElapsedSeconds { get { return _elapsedSeconds; } }

        public ViewEvent(string userId, string viewURL, DateTime start, DateTime end)
        {
            this._userId = userId;
            this._viewURL = viewURL;
            this._startDate = start;
            this._endDate = end;
            this._elapsedSeconds = (end - start).TotalSeconds;
        }
    }
}
