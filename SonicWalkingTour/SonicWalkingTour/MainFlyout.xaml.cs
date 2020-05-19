using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class MainFlyout : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        //help command to navigate to other urls
        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        //public ICommand BackCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync(".."));

        public MainFlyout()
        {
            InitializeComponent();

            RegisterRoutes();

            BindingContext = this;
        }

        //we need this method to register the routes of our other pages
        //this way we can navigate within our app
        void RegisterRoutes()
        {
            routes.Add("mapPage", typeof(MapPage));
            routes.Add("routePage", typeof(RoutePage));
            routes.Add("pinDetailPage", typeof(PinDetailPage));

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
    }
}
