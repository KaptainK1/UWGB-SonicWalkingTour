using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace SonicWalkingTour.Model
{

    //the custom pin set class will be used to store both the pins
    //and the positions on the map as a route
    public class CustomPinSet : IPinPlan, IPositionPlan
    {
        //list of pins that will be displayed on the map
        private List<CustomPin> pins;

        //list of positions to be displayed on the map as a route
        private List<Position> positions;
            
        public CustomPinSet()
        {
        }

        public void setPins(List<CustomPin> pins)
        {
            this.pins = pins;
        }

        public List<CustomPin> getPins()
        {
            return this.pins;
        }

        public void setPositions(List<Position> positions)
        {
            this.positions = positions;
        }

        public List<Position> getPositions()
        {
            return this.positions;
        }
    }
}
