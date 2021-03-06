﻿using System;
namespace SonicWalkingTour
{
    //The track Class will be used to store the songs/audio files that will be played
    public class Track
    {

        public static int TrackID { get; private set; }
        public static string TrackAudio { get; private set; }
        public static string TrackMusic { get; private set; }
        public static string TrackDescription { get; private set; }

        public Track()
        {

        }

        public Track(int trackID, string trackAudio, string trackMusic, string trackDescription)
        {
            TrackID = trackID;
            TrackAudio = trackAudio;
            TrackMusic = trackMusic;
            TrackDescription = trackDescription;
        }
    }
}
