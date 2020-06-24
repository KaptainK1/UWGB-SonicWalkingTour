using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using SonicWalkingTour.Model;
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

        public static CustomPinType indoorPin = new CustomPinType("#ff7319");
        public static CustomPinType outdoorPin = new CustomPinType("#0F5640");
        public static CustomPinType tunnelPin = new CustomPinType("#dfe4e1");
        public static CustomPinType upperFloorPin = new CustomPinType("#adffdb");

        //TODO setup Azure DB and change url
        public static MobileServiceClient MobileService = new MobileServiceClient("https://sonicwalkingtour.azurewebsites.net");

        public const string TRACK1 = "Welcome to the campus of University of Wisconsin Green Bay. Thank you for choosing to experience our Sonic Walking Tour. A Student Ambassador will be accompanying you on your journey today in case you have any questions along the way. The Sonic Walking Tour Experience is the product of a collaborative effort from members of the Computer Science, Music, Theatre & Dance Departments in association with UWGB Student Services.\n\nAnd this is where our tour begins; in front of the office of Student Services, which as the name implies, is completely dedicated to students. The first office that most students interact with is the Green Bay One Stop Shop, or as we call it, GBOSS.This is where we have our admissions department, financial aid, and academic advising.They’ll help you through the application process, answer any questions you have about admissions or finances, and will help guide you through your first year of classes.This is a great place to go with any questions or concerns you may have.Even if they don’t know the answer, they’ll connect you with someone who does.\n\nStudent Services also houses Career Services. This office is here to help you with all things related to your career.They can help you find a job, work on a resume and cover letter, practice your interview skills, and even rent out some clothes for free, if you don’t have anything to wear to an interview or job fair.UWGB offers an online job service called Handshake. It’s free for students to use, and helps you find any job you’re looking for, whether it be on-campus, off-campus, full-time, part-time, internships, and much more.\n\nDisability Services is here to help, if you have any documented disabilities.They can make any accommodations you need to ensure that your education goes as smoothly as possible.\nThe Counseling and Health Center offers many services to students. With a nurse practitioner on staff, students can come to the Health Center for checkups, and can be helped with any minor health issues.The Health Center also offers certain shots and vaccinations for a very low cost. Students can schedule up to 10 free counseling sessions per academic year at the Counseling Center. If additional counseling is needed beyond these 10 sessions, students can be referred to off-campus resources as well.\nThe Dean of Students is another very helpful office in Student Services. They’re here to make sure your education isn’t thrown off track in any major way.If any unexpected circumstances arrive that interfere with your academics, you can work with the Dean of Students, and they’ll work with your professors to make sure you don’t fall behind because of it. Once again, welcome to The University of Wisconsin’s Green Bay campus. We hope you enjoy your time with us.\nNow, please press TRACK 2.";
        public const string TRACK2 = "Let’s continue our tour. Follow your Student Ambassador as you make your way to the second stop on our tour today, Cofrin Library. Throughout our tour, enjoy original music from UWGB Music Professor Michelle McQuade Dewhirst and Music Composition student Aaron Frye.\n\nWhen we reach the Cofrin Library elevators, please press TRACK 3.";
        public const string TRACK3 = "Enter the elevator and take a ride up to the 8th floor where our tour will continue. After you exit the elevator, follow your Student Ambassador to the nearest window for a bird’s eye view of campus and press Track 4.";
        public const string TRACK4 = "Welcome to the 8th floor of Cofrin Library, the tallest building in the city of Green Bay. Standing at eight stories, this building is the center of academic life for students on this campus. The view from the 8th floor allows you to see the whole campus in all of its beauty. Take a walk from window to window and see how many buildings you are able to recognize. From the Weidner Center for the Performing Arts, to our beautiful arboretum trails and 9 hole golf course. And let’s not forget our brand new state of the art STEM building. This building encapsulates both the natural beauty, and innate drive that fosters the culture of this university. As you enjoy the view, take a moment to listen to student-poet Lori Noto’s evocative poem called Empty Nest, dedicated to Cofrin Library.\n\nWhen you are ready to continue to our next stop on the tour, press Track 5.";
        public const string TRACK5 = "Now let’s get back on the elevators and head to the 2nd floor. When the elevator doors open, follow your student ambassador to the brick ring on the floor in front of the stairway to the 1st floor and press track 6.";
        public const string TRACK6 = "In 1965 David A. Cofrin, the building’s namesake, officially completed construction of the campus. If you look on the floor, you will see a circle of bricks inlaid into the floor’s surface. David Cofrin placed this here as a reminder that he always wanted academics to be the center of focus for all students and faculty who come here, and as such, these bricks represent the geographical center of campus. The Library Commons adjacent to where you are standing is one of the most popular areas for students to study on campus. This area was designed by Psychology students in the Master’s program, who were attempting to answer the thesis question: “What does a study area need to be most effective for students?” The Commons have several different types of lounging for hard working students. From booths with complementary charging stations, to studio rooms paired with sound proof doors, and enclosed pods designed to minimize distraction. Here, there is something for every student.\n\nNow let’s continue our journey.Follow your student ambassador as they guide you out the doors leading to the Quad.\n\nPress Track 7.";
        public const string TRACK7 = "The Commons, also known as The Quad, is an enclosed open-air space between the University Union, Mary Ann Cofrin Hall and the Cofrin Library. There is a short path across it that students often use as a shortcut to go from the Library to the first floor of the Student Union without passing through MAC Hall. Big outdoor events will sometimes take place in the Quad, especially during GB Welcome week in September.It is a really nice place to hang out or do activities outside in the warmer months, but it is just as fun in the winter thanks to the big hill on one side of the Quad.After a snowstorm many students can be seen climbing up the hill in order to slide down it using sleds, coats or any other tools they might have.Although, speaking from experience, we do not recommend putting too much trust in your nice jeans to carry you smoothly to the foot of the hill.We’ve also found that is an excellent spot to build a snowman!As you take in the sights before you, listen to an original poem from Dean Chuck Rybak of the College of Arts, Humanities and Social Sciences, titled: Commons. \n\n Trunks of the first maples tail feathers\n\nBranches and their green plumage wingspan and flight\n\nPasts futures all marked present \n\n Our children roll down the hill shouting sounds\n\nto the clouds the grass clouds grass clouds\n\nTheir hopes echo off the gift of stone\n\nstirring the falcons who lay and nurture our sky\n\natop the towering nest woven in brick and questions\n\n\n\nNow follow your Student Ambassador as they lead you into the Student Union.Once you enter the building, press track 8.";
        public const string TRACK8 = "Welcome to the central hub of campus! The Student Union building has the most foot traffic out of all the other buildings on campus due to the provided hangout areas, dining locations, multipurpose rooms, the Phoenix Bookstore, and all of the wonderful amenities provided to relax, entertain, and accommodate all students.\n\nWalking through the doors you will immediately see the Cloud Commons.This is our pay once and eat all you want dining option.They have vegan and vegetarian options along with a G8 counter that avoids all 8 major food allergens for students with specific needs. There is also a dietician who will gladly talk to you about any specific food needs you may have! Across from the Cloud Commons is our campus Bookstore, which houses all the clothing swag, mugs, all ofyour books, pencils papers, notebooks, book bags, etc. for your classes or personal enjoyment.Further down the hall you will come in contact with the UW credit union if you want to open a savings or checking account, as well as the University Ticketing and Information Center that will answer any questions you may have about the location of something or tickets for any large events on or off campus.This is also where you will get your student ID. The Phoenix rooms are a multipurpose set of rooms that always have different events to entertain students when they are not in class. Just a little ways further down this hallway you will find the Corner store.We like to call it the gas station of campus with everything except the gas! It has all the essentials to cook in your residence hall or snacks on the go for class. Right next to the corner store is the Campus Coffee shop that attracts students all throughout the day.It serves bakery items, along with drinks(including starbucks products), it has a nice fireplace to warm up students on cold days, and a few times a month there is an open mic or a guest poet or performer, and there is music played all throughout the day! Let’s head downstairs.When you reach the bottom of the stairs, press track 9.";
        public const string TRACK9 = "Here there are two more eating options, the Green Bay Grill and the Phoenix club. While the Green Bay grill will satisfy your hamburger, chicken tender, smoothie, waffle fries and cheese curds needs, the Phoenix club has a variety of pizza's, bagels, mac and cheese, and brats. Attached to the Phoenix club is an array of pool tables, a ping pong table, gaming systems, and many places to sit and relax if you just want to rest and watch TV until your next class. Also, along in the central area are four lounge areas with student organization and student life coordinators. First is the Multi-Ethnic student Affairs office, second is the Student Life lounge, the Student Government area, as well as the Pride Center. All of these offices have couch areas, chairs, tables, and great environments for those who like a little background noise when they study, and tv’s when you want to keep up with your favorite shows during the day. Tucked in a corner is the Christy Theatre which is our Union movie theatre. Every week there is a movie bought in fresh from theaters before it becomes available to the general public on DVD. Student tickets are only three dollars!\n\nAs we head back to Student Services where your tour began, press track 10 to hear about our system of tunnels.";
        public const string TRACK10 = "Here at UW-Green Bay, the famous tunnels or concourses as they are also known, are an interconnected web of first floor hallways that can lead students to almost of all of our academic buildings without ever having to step foot outside. As you can imagine, this is especially helpful in the winter time. The only buildings on campus that the tunnels don’t connect to are: the Weidner Center, the Kress Events Center, the STEM Building, and housing. The first chancellor, Edward Weidner, had wanted them not only for their use in the winter time, but also to promote an inter-connectedness on campus. Each building, or area of study, is not closed off from one another, but rather open to each other, essentially creating one big building for one community\n\nAs you continue towards the Student Union, take this time to experience the sights and sounds around you by removing your headphones or earbuds. Depending on the time of day, you may bemet with the joyous cacophony of a bustling educational community or the silent serenity of a community hard at work.\n\nWhen you arrive back at Student Services, press and listen to track 11.";
        public const string TRACK11 = "You have come to the end of your Sonic Walking Tour. Take this opportunity to ask your Student Ambassador any questions you may have.\n\nOn behalf of the whole UWGB community, thanks for visiting. We hope you had a good time and look forward to seeing you again.";
        public static List<CustomPin> pins  {get; private set; }
        public static List<Track> tracks { get; private set;  }

        public App()
        {
            InitializeComponent();

            pins = InitializePins();

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


        //TODO initialize from DB source?
        protected List<CustomPin> InitializePins()
        {

            const string track4 = "Track4.mp3";
            const string track1 = "Track1.mp3";
            const string track2 = "Track2.mp3";
            const string track3 = "Track3.mp3";
            const string track5 = "Haze.mp3";
            const string track6 = "Track6.mp3";

            List<CustomPin> customPins;

            var pin1 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.532377, -87.921069),
                Description = TRACK1,
                MarkerId = "1",
                StopID = 1,
                Label = "Student Services",
                Url = track1
            };

            var pin2 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.532174, -87.921140),
                Description = TRACK2,
                MarkerId = "2",
                StopID = 2,
                Label = "Track 2",
                Url = track2
            };

            var pin3 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.531521, -87.921297),
                Description = TRACK3,
                MarkerId = "3",
                StopID = 3,
                Label = "Confrin Library Elevators",
                Url = track3
            };

            var pin4 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = upperFloorPin,
                Position = new Xamarin.Forms.Maps.Position(44.531166, -87.921602),
                Description = TRACK4,
                MarkerId = "4",
                StopID = 4,
                Label = "Confrin Library",
                Url = track4
            };

            var pin5 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.531487, -87.921233),
                Description = TRACK5,
                MarkerId = "5",
                StopID = 5,
                Label = "Confrin Library Elevators 2",
                Url = track5
            };

            var pin6 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.531400, -87.920857),
                Description = TRACK6,
                MarkerId = "6",
                StopID = 6,
                Label = "Intransit To Quad",
                Url = track6
            };

            var pin7 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = outdoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.531727, -87.920409),
                Description = TRACK7,
                MarkerId = "7",
                StopID = 7,
                Label = "The Quad",
                Url = track5 //TODO update
            };

            var pin8 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.531969, -87.920197),
                Description = TRACK8,
                MarkerId = "8",
                StopID = 8,
                Label = "The Student Union",
                Url = track5 //TODO update

            };

            var pin9 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.532295, -87.919902),
                Description = TRACK9,
                MarkerId = "9",
                StopID = 9,
                Label = "The Student Union Part 2",
                Url = track5 //TODO update
            };

            var pin10 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = tunnelPin,
                Position = new Xamarin.Forms.Maps.Position(44.532402, -87.920384),
                Description = TRACK10,
                MarkerId = "10",
                StopID = 10,
                Label = "Intransit to Student Services",
                Url = track5 //TODO update
            };

            var pin11 = new CustomPin()
            {
                Type = PinType.SavedPin,
                CustomPinType = indoorPin,
                Position = new Xamarin.Forms.Maps.Position(44.532330, -87.920784),
                Description = TRACK11,
                MarkerId = "11",
                StopID = 11,
                Label = "End of Tour, Thank you!",
                Url = track5 //TODO update
            };


            customPins = new List<CustomPin>{ pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10, pin11};
            return customPins;
        }

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
