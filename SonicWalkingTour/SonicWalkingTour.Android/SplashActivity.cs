﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
//using Android.Support.V7.App;
using Android.Support.V13;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace SonicWalkingTour.Droid
{
    //This class will be used for our splash activity, which will add a simple splash screen to our application
    //The splash screen acts as the main launcher, and once done loading will launch the MainActivity class
    //the picture is located under the drawable folder called uwgb_logo.png
    //the style we are using is under the values/styles.xml file called MainTheme.Splash
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);

        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            //Task startupWork = new Task(() => { startUp(); });
            //startupWork.Start();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        //startup our main activity class
        void StartUp()
        {
            //temporarily wait for a second to ensure the screen is displayed
            //await Task.Delay(10);
            //start the main activity
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

    }
}