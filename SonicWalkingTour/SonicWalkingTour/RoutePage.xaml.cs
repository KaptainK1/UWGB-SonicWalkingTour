using System;
using System.Collections.Generic;
using System.Windows.Input;
using SonicWalkingTour.Model;
using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class RoutePage : ContentPage, IInformationPage
    {
        public string HelpText { get; set; }

        public RoutePage()
        {
            InitializeComponent();

            HelpText = ((IInformationPage)this).GetHelpText(this.GetType().Name);

            CustomPinListView.ItemsSource = App.pins;

            this.BindingContext = this;

        }

        //we can override the back command if necessary
        //public ICommand BackCommand => new Command(async (url) => await Shell.Current.DisplayAlert("Back","Back Button pressed", "OK"));

        async void ListItem_Tapped(System.Object sender, System.EventArgs e)
        {
            var customPin = CustomPinListView.SelectedItem as CustomPin;
            string id = customPin.StopID.ToString();

            //old method of navigating, but we are no longer using a NavigationPage
            //App.Current.MainPage.Navigation.PushAsync(new PinDetailPage(customPin));

            //since we are using shell navigation, we can use URI type navigation
            //here we are going to the pinDetailPage route, and passing the stopid as parameter
            //the receiving page will consume this id, please check the comments there
            await Shell.Current.GoToAsync($"pinDetailPage?stopid={id}");
        }

        private void Help_Clicked_Base(object sender, EventArgs e)
        {
            ((IInformationPage)this).Help_Clicked(sender, e);
        }
    }
}
