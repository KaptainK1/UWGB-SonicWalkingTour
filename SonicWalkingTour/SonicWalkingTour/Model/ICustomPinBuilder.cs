using System;

namespace SonicWalkingTour.Model
{

    //Builder Interface that will help us create the CustomPinSet objects
    //that hold lists of pins and positions
    public interface ICustomPinBuilder
    {
        //method to build the pins that will be displayed on the map page
        //and on the route page
        void buildPins();

        //method to build the positions that will be used on the map page
        //this way we can build more intricate route lines
        void buildPositions();

        //getter
        CustomPinSet getPinSet();

    }
}
