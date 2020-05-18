using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace SonicWalkingTour
{

    [QueryProperty("StopID", "stopid")]
    //[QueryProperty("Description", "description")]
    //[QueryProperty("Url", "url")]
    public partial class PinDetailPage : ContentPage
    {
        private CustomPin selectedPin = null;
        public string StopID
        {
            set
            {
                BindingContext = App.pins.FirstOrDefault(p => p.StopID.ToString() == Uri.UnescapeDataString(value));
                selectedPin = App.pins.FirstOrDefault(p => p.StopID.ToString() == Uri.UnescapeDataString(value));
                player.Load(GetStreamFromFile(selectedPin.Url));

            }
        }



        //public string Description
        //{
        //    set
        //    {
        //        BindingContext = App.pins.FirstOrDefault(p => p.Description == Uri.UnescapeDataString(value));
        //    }
        //    get { return Description; }
        //}



        

        ISimpleAudioPlayer player;

        //Type = PinType.SavedPin,
        //        Position = new Xamarin.Forms.Maps.Position(44.532351, -87.920922),
        //        Description = "Here is a brief description of Student Services!",
        //        MarkerId = "1",
        //        StopID = 1,
        //        Label = "Student Services",
        //        Url = track1


        public PinDetailPage()
        {



            InitializeComponent();

            //selectedPin = pin;
            //entryTitle.Text = selectedPin.Label;
            //entryDescription.Text = selectedPin.Description;

            //player = CrossSimpleAudioPlayer.Current;
            //player.Load(GetStreamFromFile(selectedPin.Url));

            player = CrossSimpleAudioPlayer.Current;

           // player.Load(GetStreamFromFile(url.ToString()));

        }

        Stream GetStreamFromFile(string filename)
        {
            
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(App.MusicLocation + filename);
            return stream;
        }

        void Play_Clicked(object sender, System.EventArgs e)
        {

            player.Play();
        }

        void Pause_Clicked(object sender, System.EventArgs e)
        {

            player.Pause();
        }
    }
}
