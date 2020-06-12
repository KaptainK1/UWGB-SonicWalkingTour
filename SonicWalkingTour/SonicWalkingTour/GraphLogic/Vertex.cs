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

        void setStopName(string stopName)
        {
            this.stopName = stopName;
        }

        void setRouteID(int routeID)
        {
            this.routeID = routeID;
        }

        int getRouteID()
        {
            return this.routeID;
        }

        string getStopName()
        {
            return this.stopName;
        }

    }
}
