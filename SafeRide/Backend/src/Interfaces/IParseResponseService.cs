using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IParseResponseService
    {
        public Route ParseFirstRoute() {}
        
        public Dictionary<double, double> ParseStepCoordinates() {} 
    }
}
