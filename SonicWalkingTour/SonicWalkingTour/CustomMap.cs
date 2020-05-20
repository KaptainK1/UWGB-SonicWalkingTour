using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace SonicWalkingTour
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }


        public CustomMap()
        {

            //TODO these are hardcoded postion values to the center of campus
            this.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(44.531354, -87.919450), Distance.FromMiles(0.5)));
        }

    }
}
