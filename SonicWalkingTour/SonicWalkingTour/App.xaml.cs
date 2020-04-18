using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SonicWalkingTour
{
    public partial class App : Application
    {

        public static double ScreenHeight;
        public static double ScreenWidth;
        public static string MusicLocation = "SonicWalkingTour.SharedAssets.Audio.";
        public static List<CustomPin> pins;

        public App()
        {
            InitializeComponent();

            pins = InitializePins();

            MainPage = new NavigationPage(new LoginPage());
        }

        #region Load Pins from the Azure Database
        protected List<CustomPin> initPinsFromAzureDB()
        {

            List<CustomPin> customPins = new List<CustomPin>();





            return customPins;

        }
        #endregion

        protected List<CustomPin> InitializePins()
        {

            const string track4 = "Track4.mp3";
            const string track1 = "Track1.mp3";
            const string track2 = "Track2.mp3";
            const string track3 = "Track3.mp3";
            const string track5 = "Haze.mp3";

            List<CustomPin> customPins;

            var pin1 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.532351, -87.920922),
                Description = "Here is a brief description of Student Services!",
                MarkerId = "1",
                StopID = 1,
                Label = "Student Services",
                Url = track1
            };

            var pin2 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.531936, -87.921457),
                Description = "Here is a brief description of the Tunnels",
                MarkerId = "2",
                StopID = 2,
                Label = "Tunnels",
                Url = track2
            };

            var pin3 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.531397, -87.921274),
                Description = "Here is a brief description of the Confrin Library!",
                StopID = 3,
                Label = "Confrin Library",
                Url = track3
            };

            var pin4 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.532386, -87.919828),
                Description = "Here is a brief description of the Union!",
                StopID = 4,
                Label = "The Union",
                Url = track4
            };

            var pin5 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.531822, -87.920591),
                Description = "Here is a brief description of the Quad",
                MarkerId = "5",
                StopID = 5,
                Label = "The Quad",
                Url = track5
            };

            customPins = new List<CustomPin>{ pin1, pin2, pin3, pin4, pin5};
            return customPins;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
