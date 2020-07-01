using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;

namespace SonicWalkingTour.Model
{
    public class CustonPinSetDirector
    {
        private ICustomPinBuilder pinBuilder;

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
