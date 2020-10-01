using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using SonicWalkingTour.Model;
using SonicWalkingTour.Model.ImportResources;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SonicWalkingTour
{
    public partial class App : Application
    {

        public static double ScreenHeight;
        public static double ScreenWidth;
        public static string MusicLocation = "SonicWalkingTour.SharedAssets.Audio.";

        //TODO setup Azure DB and change url
        public static MobileServiceClient MobileService = new MobileServiceClient("https://sonicwalkingtour.azurewebsites.net");

        public static List<CustomPin> pins  {get; private set; }
        //public static List<Track> tracks { get; private set;  }
        public static List<Position> positions { get; private set; }
        public static Dictionary<string, string> helpTextHashTable;

        public App()
        {


            BetaFileImportBuilder betaFileImportBuilder = new BetaFileImportBuilder();
            ResourceDirector resourceDirector = new ResourceDirector(betaFileImportBuilder);
            resourceDirector.loadTextResources();
            helpTextHashTable = resourceDirector.getHashTable();

            BetaPinBuilder builder = new BetaPinBuilder();
            CustonPinSetDirector director = new CustonPinSetDirector(builder);

            InitializeComponent();

            Device.SetFlags(new[] { "Shapes_Experimental" , "MediaElement_Experimental"});

            director.makePins();
            director.makePositions();
            pins = director.getPins();
            positions = director.getPositions();

            //pins = InitializePins();

            //tracks = initTracksFromAzureDB();

            MainPage =  new MainFlyout();
        }

        #region Load Pins from the Azure Database
        protected List<CustomPin> initPinsFromAzureDB()
        {

            List<CustomPin> customPins = new List<CustomPin>();

            return customPins;

        }

        #endregion

        #region load the tracks from the Azure Database
        private List<Track> initTracksFromAzureDB()
        {
            List<Track> tracks = new List<Track>();

            for(int i = 1; i < 12; i++)
            {
                Track track = new Track();

               //TODO get track id, audio file, and description from the db then add track to the local list

            }
            return tracks;
        }
        #endregion

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
