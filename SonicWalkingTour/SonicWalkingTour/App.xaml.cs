using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SonicWalkingTour
{
    public partial class App : Application
    {

        public static double ScreenHeight;
        public static double ScreenWidth;
        public static string MusicLocation = "SonicWalkingTour.SharedAssets.Audio.";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
