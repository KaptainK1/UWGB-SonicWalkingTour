using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.SimpleAudioPlayer;
using SonicWalkingTour.Model;
using Xamarin.Forms;

namespace SonicWalkingTour
{

    //we need this query property to receive the stop id
    //from the calling pages which pass the stop id as a parameter
    [QueryProperty("RootPage", "rootPage")]
    [QueryProperty("StopID", "stopid")]

    public partial class PinDetailPage : ContentPage, IInformationPage
    {
        //custom pin object that will be set based off of the stop id passed
        private CustomPin selectedPin = null;
        private static string rootPage;
        private static Stack<decimal> previousStops = new Stack<decimal>();

        public string RootPage
        {
            set
            {
                BindingContext = Uri.UnescapeDataString(value);
                rootPage = BindingContext as string;
            }
            
        }

        //StopID property as defined in the first query property
        //we use the set method of this property to set the binding context (
        // this page's UI elements) to the results of the stop id passed
        public string StopID
        {
            set
            {
                BindingContext = App.pins.FirstOrDefault(p => p.StopID.ToString() == Uri.UnescapeDataString(value));

                //if the binding is not null
                //set the selected pin object as a custom pin
                //then load the player
                if (BindingContext != null)
                {
                    selectedPin = BindingContext as CustomPin;
                    player.Load(GetStreamFromFile(selectedPin.Url));


                }
                else
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

            player = CrossSimpleAudioPlayer.Current;

            Shell.SetBackButtonBehavior(this, new BackButtonBehavior
            {
                Command = new Command(() =>
                {
                    Shell.Current.FlyoutIsPresented = true;
                }),
                IconOverride = "uwgb_logo.png"
            });

            initControls();
        }

        void initControls()
        {
            sliderPosition.ValueChanged += SliderPostionValueChanged;
        }

        private void SliderPostionValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sliderPosition.Value != player.Duration)
                player.Seek(sliderPosition.Value);
            lblPosition.Text = $"Postion: {(int)sliderPosition.Value} / {(int)player.Duration}";
        }

        bool UpdatePosition()
        {
            lblPosition.Text = $"Postion: {(int)player.CurrentPosition} / {(int)player.Duration}";

            sliderPosition.ValueChanged -= SliderPostionValueChanged;
            sliderPosition.Value = player.CurrentPosition;
            sliderPosition.ValueChanged += SliderPostionValueChanged;

            return player.IsPlaying;
        }

        //public ICommand BackCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync($"pinDetailPage?stopid={getPreviousStopID(selectedPin.StopID)}"));
        public ICommand BackCommand => new Command<string>(async (url) => await Shell.Current.GoToAsync(url));

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

            sliderPosition.Maximum = player.Duration;
            sliderPosition.IsEnabled = player.CanSeek;

            Device.StartTimer(TimeSpan.FromSeconds(0.5), UpdatePosition);
        }

        //method to pause the audio file
        void Pause_Clicked(object sender, System.EventArgs e)
        {
            if (player.IsPlaying) {
                player.Pause();
            }
        }

        async void Go_Next(object sender, System.EventArgs e)
        {
            previousStops.Push(selectedPin.StopID);

            decimal nextPin = getNextStopID(this.selectedPin.StopID);

            Console.WriteLine(nextPin);

            //await Shell.Current.GoToAsync($"pinDetailPage?stopid={nextPin}");
            await Shell.Current.GoToAsync($"pinDetailPage?rootPage={rootPage}&stopid={nextPin}");
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

        protected override bool OnBackButtonPressed()
        {
            //decimal previousStopID = getPreviousStopID(selectedPin.StopID);

            decimal previousStopID = getPreviousStopID(selectedPin.StopID);
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (previousStopID == 0)
                {
                    await Shell.Current.GoToAsync($"{rootPage}");
                }
                else
                {
                    await Shell.Current.GoToAsync($"pinDetailPage?rootPage={rootPage}&stopid={previousStopID}");
                }

            });
            return true;
        }

        private decimal getPreviousStopID(decimal currentID)
        {

            decimal nextStopID;
            //if the count is one, then we are at the end and cant go back any further
            if(previousStops.Count == 0)
            {
                nextStopID = 0;
                Console.WriteLine($"Current StopID = {currentID}, Previous StopID = {nextStopID}");
                previousStops.Clear();
            } else
            {

                nextStopID = previousStops.Pop();
                Console.WriteLine($"Current StopID = {currentID}, Previous StopID = {nextStopID}");
            }

/*            if(nextStopID != null)
            {
                Console.WriteLine($"Current StopID = {currentID}, Previous StopID = {nextStopID}");
                return nextStopID;
            }*/

            return nextStopID;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (player.IsPlaying)
            {
                player.Pause();
            }
        }




        /*
        private async Task<Decimal> getPreviousStopID(string currentID)
        {
            decimal previousStopID;

            if (Decimal.TryParse(currentID, out previousStopID))
            {
                Console.WriteLine("Successful parse of stop id");
                
            } else
            {
                Console.WriteLine($"Unsuccessful parse of stop id {previousStopID}");
                previousStopID = 1;
                await Shell.Current.DisplayAlert("Error", "Selected pin stop ID doesnt exist", "Ok");
            }

            return previousStopID;

        }
        */
    }
}
