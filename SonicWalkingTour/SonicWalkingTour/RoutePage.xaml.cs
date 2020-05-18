using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class RoutePage : ContentPage
    {
        public RoutePage()
        {
            InitializeComponent();

            CustomPinListView.ItemsSource = App.pins;

        }

        async void ListItem_Tapped(System.Object sender, System.EventArgs e)
        {
            var customPin = CustomPinListView.SelectedItem as CustomPin;
            //string Label = customPin.Label;
            //string Description = customPin.Description;
            //string Url = customPin.Url;
            string id = customPin.StopID.ToString();

            //App.Current.MainPage.Navigation.PushAsync(new PinDetailPage(customPin));
            //await Shell.Current.GoToAsync($"{state.Location}/{destinationRoute}?name={animalName}");

            //async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
            //{
            //    string elephantName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            //    await Shell.Current.GoToAsync($"//animals/elephants/elephantdetails?name={elephantName}");
            //}
            //await Shell.Current.GoToAsync($"pinDetailPage?label={Label}&description={Description}&url={Url}");
            await Shell.Current.GoToAsync($"pinDetailPage?stopid={id}");
        }
    }
}
