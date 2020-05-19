using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class RoutePage : ContentPage
    {
        public RoutePage()
        {
            InitializeComponent();

            CustomPinListView.ItemsSource = App.pins;

            this.BindingContext = this;

        }

        //we can override the back command if necessary
        //public ICommand BackCommand => new Command(async (url) => await Shell.Current.DisplayAlert("Back","Back Button pressed", "OK"));

        async void ListItem_Tapped(System.Object sender, System.EventArgs e)
        {
            var customPin = CustomPinListView.SelectedItem as CustomPin;
            string id = customPin.StopID.ToString();

            //App.Current.MainPage.Navigation.PushAsync(new PinDetailPage(customPin));
            //await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");

            //async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
            //{
            //    string elephantName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            //    await Shell.Current.GoToAsync($"//animals/elephants/elephantdetails?name={elephantName}");
            //}
            //await Shell.Current.GoToAsync($"pinDetailPage?label={Label}&description={Description}&url={Url}");

            //since we are using shell navigation, we can use URI type navigation
            //here we are going to the pinDetailPage route, and passing the stopid as parameter
            //the receiving page will consume this id, please check the comments there
            await Shell.Current.GoToAsync($"pinDetailPage?stopid={id}");
        }
    }
}
