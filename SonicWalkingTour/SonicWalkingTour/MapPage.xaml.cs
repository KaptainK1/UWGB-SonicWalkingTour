using System;
using System.Collections.Generic;
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

        public MapPage()
        {
            InitializeComponent();

            GetPermissions();

            LoadPins();
        }

        //function to load all the pins we will be using
        private void LoadPins()
        {
            var pin4 = new CustomPin()
            {
                Type = PinType.Place,
                Position = new Xamarin.Forms.Maps.Position(44.531778, -87.920431),
                Description = "Here is a brief description of the Quad",
                MarkerId = "xamarin",
                Label = "The Quad",
                Url = track4
            };

            var pin1 = new CustomPin()
            {
                Type = PinType.Place,
                Position = new Xamarin.Forms.Maps.Position(44.533145, -87.923061),
                Description = "Here is a brief description of the Weidner",
                MarkerId = "xamarin",
                Label = "The Weidner Center",
                Url = track1
            };

            var pin2 = new CustomPin()
            {
                Type = PinType.Place,
                Position = new Xamarin.Forms.Maps.Position(44.530359, -87.916433),
                Description = "Here is a brief description of the Kress",
                MarkerId = "xamarin",
                Label = "The Kress Center",
                Url = track2
            };

            var pin3 = new CustomPin()
            {
                Type = PinType.Place,
                Position = new Xamarin.Forms.Maps.Position(44.531354, -87.919450),
                Description = "Here is a brief description of the Mary Ann Confrin",
                MarkerId = "xamarin",
                Label = "Mary Ann Confrin",
                Url = track3
            };

            // instantiate a polyline
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Green,
                StrokeWidth = 14,
                Geopath =
                            {
                                new Xamarin.Forms.Maps.Position(44.533145, -87.923061),
                                new Xamarin.Forms.Maps.Position(44.531778, -87.920431),
                                new Xamarin.Forms.Maps.Position(44.531354, -87.919450),
                                new Xamarin.Forms.Maps.Position(44.530359, -87.916433)

                            }
            };

            customMap.MapElements.Add(polyline);


            customMap.CustomPins = new List<CustomPin> { pin1, pin2, pin3, pin4 };
            customMap.Pins.Add(pin1);
            customMap.Pins.Add(pin2);
            customMap.Pins.Add(pin3);
            customMap.Pins.Add(pin4);

            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(44.531354, -87.919450), Distance.FromMiles(0.5)));

        }

        //fuction to get the location of the user then display it
        private async void GetLocation()
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
            var mapspan = new Xamarin.Forms.Maps.MapSpan(center, 0.009d, 0.009d);

            //now move to the region
            customMap.MoveToRegion(mapspan);
        }

    }
}
