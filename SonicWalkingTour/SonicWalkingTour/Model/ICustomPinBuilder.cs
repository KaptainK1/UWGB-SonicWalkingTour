using System;

namespace SonicWalkingTour.Model
{
    public interface ICustomPinBuilder
    {
        void buildPins();
        void buildPositions();
        CustomPinSet getPinSet();

    }
}
