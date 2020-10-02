using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using SonicWalkingTour.Model;

namespace SonicWalkingTour
{
    public partial class MainFlyout : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        //help command to navigate to other urls
        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public string HelpText { get; set ; }

        //public ICommand BackCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync(".."));

        public MainFlyout()
        {
            InitializeComponent();

            HelpText="Test";

            RegisterRoutes();

            BindingContext = this;
        }

        //we need this method to register the routes of our other pages
        //this way we can navigate within our app
        void RegisterRoutes()
        {
            routes.Add("mapPage", typeof(MapPage));
            routes.Add("routePage", typeof(RoutePage));
            routes.Add("registerPage", typeof(RegisterPage));
            routes.Add("pinDetailPage", typeof(PinDetailPage));
            routes.Add("informationPage", typeof(InformationPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }

        //public void Help_Clicked(object sender, EventArgs e)
        //{
        //    Shell.Current.GoToAsync($"informationPage?helpdescription={HelpText}");
        //}
    }
}
