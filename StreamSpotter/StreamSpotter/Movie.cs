using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
        public class Root
        {
            public Wishlist movies { get; set; }
        }

        public class Wishlist
        {
            public Movie[] Movie { get; set; }
        }

        public class Streaminginfo
        {
            public Netflix netflix { get; set; }
        }

        public class Netflix
        {
            public Us us { get; set; }
        }

        public class Us
        {
            public string link { get; set; }
            public int added { get; set; }
            public int leaving { get; set; }
        }
        public class Movie
        {
        public string imdbID { get; set; }
        public string tmdbID { get; set; }
        public int imdbRating { get; set; }
        public int imdbVoteCount { get; set; }
        public int tmdbRating { get; set; }
        public string backdropPath { get; set; }
        public string originalTitle { get; set; }
        public int[] genres { get; set; }
        public string[] countries { get; set; }
        public int year { get; set; }
        public int firstAirYear { get; set; }
        public int lastAirYear { get; set; }
        public int[] episodeRuntimes { get; set; }
        public string[] cast { get; set; }
        public string[] significants { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string video { get; set; }
        public string posterPath { get; set; }
        public int seasons { get; set; }
        public int episodes { get; set; }
        public int age { get; set; }
        public int status { get; set; }
        public string tagline { get; set; }
        public Streaminginfo streamingInfo { get; set; }
        public string originalLanguage { get; set; }

        public Movie(string title,string description,string streamService)
        {
            this.title = title;
            this.overview = description;
            //this.streamService = streamService;
        }
    }
}
