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

        public MapPage()
        {
            InitializeComponent();

            GetPermissions();

            LoadPins();
        }

        //protected override bool OnBackButtonPressed()
        //{
        //    return base.OnBackButtonPressed();
        //}

        //function to load all the pins we will be using
        #region function for loading the pins defined in the App.xaml.cs into the map page
        private void LoadPins()
        {

            // instantiate a polyline
            // this could be a simple way to draw a path between points
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Green,
                StrokeWidth = 10,
                Geopath =
                            {

                                new Xamarin.Forms.Maps.Position(44.532377, -87.921069),
                                new Xamarin.Forms.Maps.Position(44.532174, -87.921140),
                                new Xamarin.Forms.Maps.Position(44.531521, -87.921297),
                                new Xamarin.Forms.Maps.Position(44.531166, -87.921602),
                                new Xamarin.Forms.Maps.Position(44.531521, -87.921297),
                                new Xamarin.Forms.Maps.Position(44.531400, -87.920857),
                                new Xamarin.Forms.Maps.Position(44.531727, -87.920409),
                                new Xamarin.Forms.Maps.Position(44.531969, -87.920197),
                                new Xamarin.Forms.Maps.Position(44.532295, -87.919902),
                                new Xamarin.Forms.Maps.Position(44.532402, -87.920384),
                                new Xamarin.Forms.Maps.Position(44.532330, -87.920784)

                            }
            };

            //add the line between the points
            customMap.MapElements.Add(polyline);
            customMap.CustomPins = App.pins;


            foreach (CustomPin pin in App.pins)
            {
                customMap.Pins.Add(pin);
                Console.WriteLine(pin.Description);
            }
        }

        #endregion

        #region get the current user's location then move to it
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
        #endregion

        #region make sure we have the user's permissions
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
        #endregion


        #region method to handle the on appearing method for this page
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

        #endregion


        #region method to handle the on disappearing method for this page
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            //stop listening for positon changes
            CrossGeolocator.Current.StopListeningAsync();

            //unscribscibe form position locator event handler
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        #endregion

        #region event for handling the user's postion changing
        void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        #endregion

        #region method to move the map to the user's position
        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            //get the center in lat, long
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            //get the span of the map with the center
            var mapspan = new Xamarin.Forms.Maps.MapSpan(center, 0.0015d, 0.0015d);

            //now move to the region
            customMap.MoveToRegion(mapspan);
        }
        #endregion

    }
}
