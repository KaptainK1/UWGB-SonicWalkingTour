using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Plugin.SimpleAudioPlayer;
using SonicWalkingTour.Model;
using Xamarin.Forms;

namespace SonicWalkingTour
{

    //we need this query property to receive the stop id
    //from the calling pages which pass the stop id as a parameter
    [QueryProperty("StopID", "stopid")]
    public partial class PinDetailPage : ContentPage, IInformationPage
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

        public string HelpText { get; set; }

        ISimpleAudioPlayer player;

        public PinDetailPage()
        {

            InitializeComponent();

            HelpText = ((IInformationPage)this).GetHelpText(this.GetType().Name);

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

        async void Go_Next(object sender, System.EventArgs e)
        {
            decimal nextPin = getNextStopID(this.selectedPin.StopID);
            //int testIfDecimal = (int)nextPin;

            //if (testIfDecimal == nextPin)
            //{
            //    nextPin = (nextPin + 1) % App.pins.Count;
            //} else
            //{
            //    nextPin = Decimal.Add(nextPin, .1m) % App.pins.Count;
            //}

            //decimal nextPin = ((this.selectedPin.StopID + 1) % App.pins.Count);
            Console.WriteLine(nextPin);

            await Shell.Current.GoToAsync($"pinDetailPage?stopid={nextPin}");


        }

        private void Help_Clicked_Base(object sender, EventArgs e)
        {
            ((IInformationPage)this).Help_Clicked(sender, e);
        }

        private decimal getNextStopID(decimal currentID)
        {
            decimal nextStopID;

            CustomPin currentPin = App.pins[0];

            for (int i = 0; i < App.pins.Count; i++)
            {
                if (currentID == App.pins[i].StopID)
                {
                  return  nextStopID = App.pins[(i + 1)  % (App.pins.Count)].StopID;
                }

            }
            return 0;
        }
    }
}
