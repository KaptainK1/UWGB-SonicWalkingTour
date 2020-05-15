using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class MainFlyout : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        public MainFlyout()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            routes.Add("MapPage", typeof(MapPage));
            routes.Add("RoutePage", typeof(RoutePage));

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
