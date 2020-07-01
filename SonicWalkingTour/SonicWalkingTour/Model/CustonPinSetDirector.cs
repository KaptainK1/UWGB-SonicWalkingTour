using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;

namespace SonicWalkingTour.Model
{
    //The director is the top level class that we will be using to make the pins, and positions
    //and get those pins and positions directly from the builder class 
    public class CustonPinSetDirector
    {
        //using composition, have an object that is set to a builder object
        private ICustomPinBuilder pinBuilder;

        //now set the passed in builder to our private instance
        public CustonPinSetDirector(ICustomPinBuilder builder)
        {
            this.pinBuilder = builder;

        }

        public CustomPinSet getPinSet()
        {
            return this.pinBuilder.getPinSet();
        }

        public void makePins()
        {
            this.pinBuilder.buildPins();
        }

        public List<CustomPin> getPins()
        {
            return this.pinBuilder.getPinSet().getPins();
        }

        public void makePositions()
        {
            this.pinBuilder.buildPositions();
        }

        public List<Position> getPositions()
        {
            return this.pinBuilder.getPinSet().getPositions();
        }
    }
}
