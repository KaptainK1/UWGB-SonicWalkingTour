using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace SonicWalkingTour.Model
{
    public interface IPositionPlan
    {
        void setPositions(List<Position> positions);
        List<Position> getPositions();
    }
}
