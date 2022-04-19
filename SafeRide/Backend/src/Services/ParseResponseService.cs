using SafeRide.src.Interfaces;
using SafeRide.src.Models;
using SafeRide.src.DataAccess;

namespace SafeRide.src.Services
{
    public class ParseResponseService : IParseResponseService
    {
        private string _jsonResponse;
        private List<Maneuver> _maneuvers;
        private List<Coordiantes> _turnCoordinates;
        
        public List<Maneuver> ParseForManeuvers(){
            this._maneuvers = JsonConvert.DeserializeObject<Maneuver>(jsonResponse);
        } 
        public List<Coordinate> ParseForTurnCoordinates() {
            for (int i = 0; i < _maneuvers.Count; i++) {
                turnX = _maneuvers[i].Location[0];
                turnY = _maneuvers[i].Location[1];
                _turnCoordinates.Add(new Coordinate(turnX, turnY));
            }
        }
    }
} 
