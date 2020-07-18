using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using SonicWalkingTour.Model;

namespace SonicWalkingTour
{
    public class CustomPin : Pin
    {

        public string Url { get; set; }
        public string Description { get; set; }
        public decimal StopID { get; set; }
        public CustomPinType CustomPinType;

        //TODO need to have a way of connecting pins to each other
        //public List<Edge> connectedEdges { get; set; }
        
        //add property for the next pin and previous pin?
        //this would give us a graph structure
    }
}
