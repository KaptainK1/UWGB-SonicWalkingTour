using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Plugin.SimpleAudioPlayer;
using Xamarin.Forms;

namespace SonicWalkingTour
{
    public partial class PinDetailPage : ContentPage
    {
        private CustomPin selectedPin = null;
        ISimpleAudioPlayer player;
        public PinDetailPage(CustomPin pin)
        {
            InitializeComponent();

            selectedPin = pin;
            entryTitle.Text = selectedPin.Label;
            entryDescription.Text = selectedPin.Description;

            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStreamFromFile(selectedPin.Url));

        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("SonicWalkingTourDemo.SharedAssets.Audio." + filename);
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
