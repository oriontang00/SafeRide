using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IParseResponseService
    {
        public MapRoute ParseFirstRoute() {}
        
        public Dictionary<double, double> ParseStepCoordinates() {} 
    }
}
