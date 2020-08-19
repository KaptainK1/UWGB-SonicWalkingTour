using SonicWalkingTour.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SonicWalkingTour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        bool isLoginButtonVisible;
        ToolbarItem toolbarLoginButton = new ToolbarItem{
                Text = "Login",
                IconImageSource = ImageSource.FromFile("arrow_left.png"),
                Order=ToolbarItemOrder.Primary,
                Priority=1
            };

        public RegisterPage()
        {
            isLoginButtonVisible = false;
            toolbarLoginButton.Clicked += Login_Clicked;
            InitializeComponent();
            CheckSubmitButton();

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

        async private void DisplayLogin_Clicked(System.Object sender, System.EventArgs e)
        {
           //this.LoginFrame.IsVisible = true;

            if (this.LoginFrame.IsVisible == true)
            {
                this.LoginFrame.IsVisible = false;
            } else
            {
                this.LoginFrame.IsVisible = true;
                await this.LoginFrame.TranslateTo(0, 20, 1000);
                //await this.LoginFrame.Op
            }

            CheckSubmitButton();
        }

        private void addLoginButton()
        {
            if(this.ToolbarItems.Count <= 1 )
            {
                this.ToolbarItems.Add(toolbarLoginButton);
            }
        }

        private void removeLoginButton()
        {
            if (this.ToolbarItems.Count > 1)
            {
                this.ToolbarItems.Remove(toolbarLoginButton);
            }
        }

        public void CheckSubmitButton()
        {
            if(isLoginButtonVisible == true)
            {
                isLoginButtonVisible = false;
                removeLoginButton();
            } else
            {
                isLoginButtonVisible = true;
                addLoginButton();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckSubmitButton();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            isLoginButtonVisible = true;
            CheckSubmitButton();
        }

    }
}