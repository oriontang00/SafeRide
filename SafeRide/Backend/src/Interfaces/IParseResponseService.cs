using SafeRide.src.Models;

namespace SafeRide.src.Interfaces
{
    public interface IParseResponseService
    {
        public List<Maneuver> ParseForManeuvers() {}
        public List<Coordinate> ParseForCoordinates() {} 

    }
}
