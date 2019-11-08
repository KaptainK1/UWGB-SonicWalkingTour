using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        void Login_Clicked(object sender, System.EventArgs e)
        {
            //got to the main page
            Navigation.PushAsync(new MainPage());
        }
    }
}
