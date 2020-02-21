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
    }
}
