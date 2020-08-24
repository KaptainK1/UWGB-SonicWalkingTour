using SonicWalkingTour.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SonicWalkingTour
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage, IInformationPage
    {
        //If this is false, then the login button is removed from the tool bar and the login frame will be shown
        bool toggleLoginButtonAndHideLoginFrame = false;
        ToolbarItem toolbarLoginButton = new ToolbarItem{
                Text = "Login",
                IconImageSource = ImageSource.FromFile("arrow_left.png"),
                Order=ToolbarItemOrder.Primary,
                Priority=1
            };

        public string HelpDescription { get; set; }
        public string HelpText { get ; set ; }

        public RegisterPage()
        {
            InitializeComponent();

            HelpText = "Test";
            //toggleLoginButtonAndHideLoginFrame = false;
            toolbarLoginButton.Clicked += Login_Clicked;
            //CheckToggleForLoginButton();

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

        private void DisplayLogin_Clicked(System.Object sender, System.EventArgs e)
        {
           //this.LoginFrame.IsVisible = true;

            //if (this.LoginFrame.IsVisible == false)
            //{
            //    this.LoginFrame.IsVisible = true;
            //    this.LoginFrame.TranslateTo(0, 100, 1000);

            //} else
            //{
            //    this.LoginFrame.IsVisible = false;
            //}

            CheckToggleForLoginButton();
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

        //function to check if the toggleLoginButtonAndHideLoginFrame value is true or false
        //if that bool is true, then we need to remove the login button and hide the login frame
        public void CheckToggleForLoginButton()
        {
            if(toggleLoginButtonAndHideLoginFrame == true)
            {
                toggleLoginButtonAndHideLoginFrame = false;
                removeLoginButton();
                UnToggleLoginFrame();
            } 
            else
            {
                toggleLoginButtonAndHideLoginFrame = true;
                addLoginButton();
                ToggleLoginFrame();

            }
        }

        async private void ToggleLoginFrame()
        {
            this.LoginFrame.IsVisible = true;
            this.LoginFrame.Opacity = 1;
            await this.LoginFrame.TranslateTo(0, 100, 1000);
        }

        async private void UnToggleLoginFrame()
        {
            await this.LoginFrame.FadeTo(0, 1200);
            this.LoginFrame.IsVisible = false;
            await this.LoginFrame.TranslateTo(0, -100, 1);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            toggleLoginButtonAndHideLoginFrame = true;
            CheckToggleForLoginButton();
        }

        private void Help_Clicked_Base(object sender, EventArgs e)
        {
            ((IInformationPage)this).Help_Clicked(sender, e);
        }
    }
}