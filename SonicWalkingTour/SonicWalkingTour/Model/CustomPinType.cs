using System;
namespace SonicWalkingTour.Model
{
    public class CustomPinType
    {
        private string BackgroundColor;

        public CustomPinType(string BackgroundColor)
        {
            this.BackgroundColor = BackgroundColor;
        }

        public string getBackgroundColor()
        {
            return this.BackgroundColor;
        }

        public void setBackgroundColor(string color)
        {
            this.BackgroundColor = color;
        }

    }
}
