﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SonicWalkingTour.Model;
using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();


            //generateToken();
        }

        /*
        void Login_Clicked(object sender, System.EventArgs e)
        {
            //got to the main page
            Navigation.PushAsync(new MainPage());

            //await generateToken();
        }
        */

        void Continue_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Hello", "Welcome ", "OK");
            //Navigation.PushAsync(new MainFlyout());
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            

        }

        //TODO update to use Azure db to track people who registered
        private async void Register_Clicked(object sender, System.EventArgs e)
        {
            if (entryEmail.Text != null && entryName.Text != null)
            {
                UserRegistration user = new UserRegistration()
                {
                    fullName = entryName.Text.Trim(),
                    email = entryEmail.Text.Trim()
                };
                
                register.IsEnabled = false;
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;

                await DisplayAlert("Hello", "Welcome " + user.fullName, "OK");
                await App.MobileService.GetTable<UserRegistration>().InsertAsync(user);
                //Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            }
            else
            {
                await DisplayAlert("Error", "Name field or email is empty, please re-enter or continue as guest", "OK");
            }
            //DisplayAlert("Hello","Welcome " + entryName.Text, "OK");
            //register.IsEnabled = false;
            ////Navigation.PushAsync(new MainPage());
            //Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;

        }

        //method to generate the token
        //calls my local web service running on localhost
        async Task generateToken()
        {

            string text = "";
            HttpClient client = new HttpClient();

            if (Device.RuntimePlatform == Device.iOS)
            {
                try
                {
                    text = await client.GetStringAsync("http://localhost:3000/token");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    //if there is an error just generate a local token
                    text = generateLocalToken();
                }


                Console.WriteLine("Token is: " + text);
                client.Dispose();
            }
            else if (Device.RuntimePlatform == Device.Android)
            {

                try
                {
                    text = await client.GetStringAsync("http://10.0.2.2:3000/token");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    //if there is an error just generate a local token
                    text = generateLocalToken();
                }


                Console.WriteLine("Token is: " + text);
                client.Dispose();

            }

        }

        string generateLocalToken()
        {
            string token = "";

            Random random = new Random();

            for(int i = 0; i < 5; i++)
            {
                token = token + random.Next(1, 9);

            }

            return token;

        }
    }
}
