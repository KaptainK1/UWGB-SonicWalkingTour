using SonicWalkingTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SonicWalkingTour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        bool isMenuItemEnabled = false;
        public bool IsMenuItemEnabled
        {
            get { return isMenuItemEnabled; }
            set
            {
                isMenuItemEnabled = value;
                MyCommand.ChangeCanExecute();
            }
        }

        public Command MyCommand { get; private set; }



        public RegisterPage()
        {
            InitializeComponent();

            MyCommand = new Command(() =>
            {
                Console.WriteLine(isMenuItemEnabled);
                DisplayAlert("Hello", "Welcome ", "OK");
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
            },
            () => IsMenuItemEnabled);
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

        private void Continue_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Hello", "Welcome ", "OK");
            //Navigation.PushAsync(new MainFlyout());
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;

        }

        private void Login_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Hello", "Welcome ", "OK");
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }

        private void DisplayLogin_Clicked(System.Object sender, System.EventArgs e)
        {
            this.LoginFrame.IsVisible = true;
            ((Command)MyCommand).ChangeCanExecute();
            isMenuItemEnabled = true;
            //this.LoginButton.IsEnabled = true;
        }
    }
}