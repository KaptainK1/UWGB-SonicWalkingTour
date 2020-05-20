using System;
using System.Collections.Generic;

namespace SonicWalkingTour
{

    //the Pin Graph will serve as the base object that will contain
    //all the vertices and edges for our map graph

    //Still a W.I.P!
    //TODO finish pin graph data structure
    public class PinGraph
    {
        //double linked list to hold our vertices
        //each vertice contains a list of edges
        //each edge has a start node, end node, and route ID
        private List<CustomPin> vertices;
        private List<Edge> edges = new List<Edge>();
        private int routeID;

        public PinGraph(List<CustomPin> vertices, int routeID)
        {

            this.vertices = vertices;
            this.routeID = routeID;

        }

        protected void initEdges()
        {

            for (int i = 0; i < vertices.Count -1; i++)
            {
                CustomPin startingPin = vertices[i];
                CustomPin endingPin = vertices[i + 1];

                Edge edge = new Edge(startingPin, endingPin, this.routeID);
                edges.Insert(i,edge);
            }
        }

        //method to get the next node for the route, specified by route ID
        public CustomPin getNextNode(CustomPin currentPin, int routeID)
        {

            //return currentPin.connectedEdges[routeID].endingVertex;
            return null;

        }

        /*
        //method to get the previous node in the route, specified by
        //the current node and the route ID
        public CustomPin getPreviousNode(CustomPin customPin, int routeID)
        {

            LinkedListNode<CustomPin> current = vertices.Find(customPin);
            CustomPin previous = current.Previous.Value;
            return previous.connectedEdges[routeID].endingVertex;

        }
        */
    }
}
