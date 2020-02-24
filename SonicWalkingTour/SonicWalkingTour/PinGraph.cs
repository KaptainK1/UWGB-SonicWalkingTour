using System;
using System.Collections.Generic;

namespace SonicWalkingTour
{

    //the Pin Graph will serve as the base object that will contain
    //all the vertices and edges for our map graph

    //Still a W.I.P!
    public class PinGraph
    {
        //double linked list to hold our vertices
        //each vertice contains a list of edges
        //each edge has a start node, end node, and route ID
        private LinkedList<CustomPin> vertices;

        public PinGraph(LinkedList<CustomPin> vertices)
        {
            this.vertices = vertices;

        }

        //method to get the next node for the route, specified by route ID
        public CustomPin getNextNode(CustomPin currentPin, int routeID)
        {

            return currentPin.connectedEdges[routeID].endingVertex;

        }

        //method to get the previous node in the route, specified by
        //the current node and the route ID
        public CustomPin getPreviousNode(CustomPin customPin, int routeID)
        {

            LinkedListNode<CustomPin> current = vertices.Find(customPin);
            CustomPin previous = current.Previous.Value;
            return previous.connectedEdges[routeID].endingVertex;

        }
    }
}
