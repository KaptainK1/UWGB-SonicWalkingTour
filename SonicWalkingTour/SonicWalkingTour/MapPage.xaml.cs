using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SonicWalkingTour
{
    public partial class MapPage : ContentPage
    {

        //boolean to hold if we have permission or not for location
        bool hasLocationPermission = false;
        const string track4 = "Track4.mp3";
        const string track1 = "Track1.mp3";
        const string track2 = "Track2.mp3";
        const string track3 = "Track3.mp3";
        const string track5 = "Haxe.mp3";

        public MapPage()
        {
            InitializeComponent();

            GetPermissions();

            LoadPins();
        }

        //function to load all the pins we will be using
        private void LoadPins()
        {

            var pin1 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.532351, -87.920922),
                Description = "Here is a brief description of Student Services!",
                MarkerId = "xamarin",
                Label = "Student Services",
                Url = track1
            };

            var pin2 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.531936, -87.921457),
                Description = "Here is a brief description of the Tunnels",
                MarkerId = "xamarin",
                Label = "Tunnels",
                Url = track2
            };

            var pin3 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.531397, -87.921274),
                Description = "Here is a brief description of the Confrin Library!",
                MarkerId = "xamarin",
                Label = "Confrin Library",
                Url = track3
            };

            var pin4 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.532386, -87.919828),
                Description = "Here is a brief description of the Union!",
                MarkerId = "xamarin",
                Label = "The Union",
                Url = track4
            };

            var pin5 = new CustomPin()
            {
                Type = PinType.SavedPin,
                Position = new Xamarin.Forms.Maps.Position(44.531822, -87.920591),
                Description = "Here is a brief description of the Quad",
                MarkerId = "xamarin",
                Label = "The Quad",
                Url = track5
            };

            // instantiate a polyline
            // this could be a simple way to draw a path between points
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Green,
                StrokeWidth = 14,
                Geopath =
                            {
                                pin1.Position,
                                pin2.Position,
                                pin3.Position,
                                pin4.Position,
                                pin5.Position

                            }
            };

            //add the line between the points
            customMap.MapElements.Add(polyline);

            //create a list of pins then add them to the map
            customMap.CustomPins = new List<CustomPin> { pin1, pin2, pin3, pin4, pin5 };
            customMap.Pins.Add(pin1);
            customMap.Pins.Add(pin2);
            customMap.Pins.Add(pin3);
            customMap.Pins.Add(pin4);
            customMap.Pins.Add(pin5);

            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(44.531354, -87.919450), Distance.FromMiles(0.5)));

        }

        //fuction to get the location of the user then display it
        private async Task GetLocation()
        {
            //if we have permission, move to the user's location
            if (hasLocationPermission)
            {
                //get the location
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);

            }
        }

        //fuction to get location permissions from the user
        private async void GetPermissions()
        {

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

                //loop while the permission is not granted
                while (status != PermissionStatus.Granted)
                {

                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location!", "We need access to your location for this app to work", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);

                    //if we have permission, set the status to Permission.LocationWhenInUse
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = results[Permission.LocationWhenInUse];
                    }
                }

            }
            catch (Exception e)
            {
                await DisplayAlert("Error", e.Message, "OK");
            }

            //now display the user
            hasLocationPermission = true;
            customMap.IsShowingUser = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.FromSeconds(5.0d), 300);

                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //stop listening for positon changes
            CrossGeolocator.Current.StopListeningAsync();

            //unscribscibe form position locator event handler
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            //get the center in lat, long
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            //get the span of the map with the center
            var mapspan = new Xamarin.Forms.Maps.MapSpan(center, 0.0015d, 0.0015d);

            //now move to the region
            customMap.MoveToRegion(mapspan);
        }

    }
}
