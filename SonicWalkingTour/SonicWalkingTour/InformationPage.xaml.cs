using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SonicWalkingTour
{
    [QueryProperty("HelpDescription", "helpdescription")]
    public partial class InformationPage : ContentPage
    {

        public string HelpDescription
        {
            set
            {
                BindingContext = Uri.UnescapeDataString(value.Normalize());
                labelHelpDescription.Text = Uri.UnescapeDataString(value.Normalize());
            }
        }

        public InformationPage()
        {
            InitializeComponent();

            BindingContext = this;
        }
    }
}
