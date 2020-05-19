using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace SonicWalkingTour
{

    //we need this query property to receive the stop id
    //from the calling pages which pass the stop id as a parameter
    [QueryProperty("StopID", "stopid")]
    public partial class PinDetailPage : ContentPage
    {
        //custom pin object that will be set based off of the stop id passed
        private CustomPin selectedPin = null;

        //StopID property as defined in the first query property
        //we use the set method of this property to set the binding context (
        // this page's UI elements) to the results of the stop id passed
        public string StopID
        {
            set
            {
                BindingContext = App.pins.FirstOrDefault(p => p.StopID.ToString() == Uri.UnescapeDataString(value));
                //selectedPin = App.pins.FirstOrDefault(p => p.StopID.ToString() == Uri.UnescapeDataString(value));

                //if the binding is not null
                //set the selected pin object as a custom pin
                //then load the player
                if (BindingContext != null)
                {
                    selectedPin = BindingContext as CustomPin;
                    player.Load(GetStreamFromFile(selectedPin.Url));
                } else
                {
                    Shell.Current.DisplayAlert("Error", "Selected pin stop ID doesnt exist", "Ok");
                    return;
                }
            }
        }

        ISimpleAudioPlayer player;

        public PinDetailPage()
        {

            InitializeComponent();

            BindingContext = this;

            //selectedPin = pin;
            //entryTitle.Text = selectedPin.Label;
            //entryDescription.Text = selectedPin.Description;

            //player = CrossSimpleAudioPlayer.Current;
            //player.Load(GetStreamFromFile(selectedPin.Url));

            player = CrossSimpleAudioPlayer.Current;

           // player.Load(GetStreamFromFile(url.ToString()));

        }

        //method to get the audio stream from the track name passed
        Stream GetStreamFromFile(string filename)
        {
            
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(App.MusicLocation + filename);
            return stream;
        }

        //method to play the audio file
        void Play_Clicked(object sender, System.EventArgs e)
        {

            player.Play();
        }

        //method to pause the audio file
        void Pause_Clicked(object sender, System.EventArgs e)
        {

            player.Pause();
        }
    }
}
