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

        void ListItem_Tapped(System.Object sender, System.EventArgs e)
        {
            var customPin = CustomPinListView.SelectedItem as CustomPin;
            //var test = sender;

            App.Current.MainPage.Navigation.PushAsync(new PinDetailPage(customPin));
        }
    }
}
