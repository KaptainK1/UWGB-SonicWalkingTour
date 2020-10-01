using System;
using Xamarin.Forms;

namespace SonicWalkingTour.Model
{

    //interface to help with displaying help information for each page
    //each page will implement this interface and to use just set the Help Text string
    //then implment the button to be pressed in xaml.
    //in the backend of the page, add the button function call this help clicked button by casting as an IInformationPage
    public interface IInformationPage
    {

        public string HelpText { get; set; }
        public void Help_Clicked(System.Object sender, System.EventArgs e)
        {
            Shell.Current.GoToAsync($"informationPage?helpdescription={HelpText}");
        }
        public string GetHelpText(string page)
        {
            string helpText;

            if (App.helpTextHashTable.TryGetValue(page, out helpText))
            {
                return helpText;
            }
            else
            {
                return null;
            }
        }
    }
}
