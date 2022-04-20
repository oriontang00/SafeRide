using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeRide.src.Models
{
    /// <summary>
    /// Stores all serialized data from API Directions response
    /// </summary>
    public class DirectionsResponse 
    {
        private List<MapRoute> routes;
        private List<Object> waypoints;
        private string code;
        private string uuid;


        public DirectionsResponse(List<MapRoute> routes, List<object> waypoints, string code, string uuid)
        {
            this.routes = routes;
            this.waypoints = waypoints;
            this.code = code;
            this.uuid = uuid;
        }

        public List<MapRoute> Routes { get => routes; set => routes = value; }
        public List<object> Waypoints { get => waypoints; set => waypoints = value; }
        public string Code { get => code; set => code = value; }
        public string Uuid { get => uuid; set => uuid = value; }
    }
}