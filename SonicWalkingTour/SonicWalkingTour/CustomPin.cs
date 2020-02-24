using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;

namespace SonicWalkingTour
{
    public class CustomPin : Pin
    {

        public string Url { get; set; }
        public string Description { get; set; }
        public int StopID { get; set; }
        public List<Edge> connectedEdges { get; set; }
        
        //add property for the next pin and previous pin?
        //this would give us a graph structure
    }
}
