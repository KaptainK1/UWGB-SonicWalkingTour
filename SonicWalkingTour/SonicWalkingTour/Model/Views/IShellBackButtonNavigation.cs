using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SonicWalkingTour.Model.Views
{

    interface IShellBackButtonNavigation
    {
        public BackButtonBehavior backButtonBehavior { get; set; }

        bool ShellBackButtonPressed();
    }
}
