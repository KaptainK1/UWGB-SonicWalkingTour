using System;
using System.Collections.Generic;
using System.Text;

namespace SonicWalkingTour.GraphLogic
{

    class Vertex
    {
        private int routeID;
        private string stopName;
        
        public Vertex()
        {
            setRouteID(0);
            setStopName("Main Route");
        }

        public Vertex(int routeID, string stopName)
        {
            setRouteID(routeID);
            setStopName(stopName);
        }

        public void setStopName(string stopName)
        {
            this.stopName = stopName;
        }

        public void setRouteID(int routeID)
        {
            this.routeID = routeID;
        }

        public int getRouteID()
        {
            return this.routeID;
        }

        public string getStopName()
        {
            return this.stopName;
        }

    }
}
