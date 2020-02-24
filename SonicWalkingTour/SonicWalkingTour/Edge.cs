using System;
namespace SonicWalkingTour
{
    //the Edge class will connect two vertices together in a nondirected way
    //a route ID will be used to determine the path to take from node to node
    //depending on the route that is selected
    public class Edge
    {

        public CustomPin startingVertex { get; set; }
        public CustomPin endingVertex { get; set; }
        public int routeID { get; set; }

        public Edge(CustomPin startingVertex, CustomPin endingVertex, int routeID)
        {
            this.startingVertex = startingVertex;
            this.endingVertex = endingVertex;
            this.routeID = routeID;

        }
    }
}
