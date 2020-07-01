using System;
using System.Collections.Generic;

namespace SonicWalkingTour.Model
{
    public interface IPinPlan
    {
        void setPins(List<CustomPin> pins);
        List<CustomPin> getPins();

    }
}
