using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SonicWalkingTour.GraphLogic
{
    class DirectedGraph
    {
        //private string route;
        private List< List <Vertex>> startingNodes;

        public DirectedGraph(int numberOfStartingNodes)
        {
            init(numberOfStartingNodes);
        }

        public DirectedGraph(List<List<Vertex>> startingNodes)
        {
            this.startingNodes = startingNodes;
        }

        public DirectedGraph()
        {
            init(5);
        }

        public void iterate()
        {
            for (int i = 0; i < startingNodes.Count; i++)
            {
                for (int j = 0; j < startingNodes.ElementAt(i).Count; j++)
                {
                    Console.WriteLine(startingNodes.ElementAt(i).ElementAt(j).getRouteID() + " " + startingNodes.ElementAt(i).ElementAt(j).getStopName());
                }

                Console.WriteLine();
            }
        }

        //method to add an edge to the end of a route for a starting node
        public int addEdge(string vertex, string edge, string routeName)
        {
            int _startingSpot;
            int _edge;

            bool vertexSuccess = int.TryParse(vertex, out _startingSpot);
            bool edgeSuccess = int.TryParse(edge, out _edge);

            if (vertexSuccess == false || edgeSuccess == false)
            {
                Console.WriteLine("Error with starting spot or edge value, please try again");
                return 1;
            }

            if(_startingSpot > this.startingNodes.Count() || _startingSpot < 0)
            {
                Console.WriteLine("Error with inserting vertex " + _startingSpot + " As this starting route doesn't exist!");
                return 1;
            }

            if (_edge < 0 || _edge > Int32.MaxValue)
            {
                Console.WriteLine("Edge is not a valid Number!");
                return 1;
            }

            Vertex vertex1 = new Vertex(_edge, routeName);
            this.startingNodes.ElementAt(_startingSpot).Add(vertex1);

            return 0;
        }

        //method to initialze the nested list, each number passed in will represent a different route
        void init(int numberOfStartingNodes)
        {
            for (int i = 0; i < numberOfStartingNodes; i++)
            {
                this.startingNodes.Add(new List<Vertex>());
            }

        }

        //method to add a new route set
        public void addNewRoute()
        {
            this.startingNodes.Add(new List<Vertex>());
        }




    }
}
