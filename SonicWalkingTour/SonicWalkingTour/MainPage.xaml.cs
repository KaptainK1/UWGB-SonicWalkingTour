using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SonicWalkingTour
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


    public partial class MainPage : TabbedPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        void ToolBar_Clicked(object sender, System.EventArgs e)
        {
            //got to the main page
            //Navigation.PushAsync(new MainPage());
        }

    }
}
