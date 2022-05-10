//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    /*******************************************************************************************************
     * Stores all of the movie/series' details, like release date, title, description, where to find it, etc.
     * Due to the API passing the Results to us, formatting could not be changed.
     *******************************************************************************************************/
    public class RootObject
    {
        public Result[] results { get; set; }
        public int total_pages { get; set; }
    }

    public class Streaminginfo
    {
        public Netflix netflix { get; set; }
        public Disney disney { get; set; }
        public Hulu hulu { get; set; }
        public Prime prime { get; set; }
    }
    public class Netflix
    {
        public Us us { get; set; }
    }
    public class Disney
    {
        public Us us { get; set; }
    }
    public class Hulu
    {
        public Us us { get; set; }
    }
    public class Prime
    {
        public Us us { get; set; }
    }
    public class Us
    {
        public string link { get; set; }
        public int added { get; set; }
        public long leaving { get; set; }
    }
    public class Backdropurls
    {
        public string _1280 { get; set; }
        public string _300 { get; set; }
        public string _780 { get; set; }
        public string original { get; set; }
    }

    public class Posterurls
    {
        public string _154 { get; set; }
        public string _185 { get; set; }
        public string _342 { get; set; }
        public string _500 { get; set; }
        public string _780 { get; set; }
        public string _92 { get; set; }
        public string original { get; set; }
    }
    public class Result
        {
        public string imdbID { get; set; }
        public string tmdbID { get; set; }
        public int imdbRating { get; set; }
        public int imdbVoteCount { get; set; }
        public int tmdbRating { get; set; }
        public string backdropPath { get; set; }
        public Backdropurls backdropURLs { get; set; }
        public string originalTitle { get; set; }
        public int[] genres { get; set; }
        public string[] countries { get; set; }
        public int year { get; set; }
        public int firstAirYear { get; set; }
        public int lastAirYear { get; set; }
        public int runtime { get; set; }
        public int[] episodeRuntimes { get; set; }
        public string[] cast { get; set; }
        public string[] significants { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string video { get; set; }
        public string posterPath { get; set; }
        public Posterurls posterURLs { get; set; }
        public int seasons { get; set; }
        public int episodes { get; set; }
        public int age { get; set; }
        public int status { get; set; }
        public string tagline { get; set; }
        public Streaminginfo streamingInfo { get; set; }
        public string originalLanguage { get; set; }

        public Result(string title,string description,string streamService)
        {
            this.title = title;
            this.overview = description;
            //this.streamService = streamService;
        }
        public Result(string[] searchResult)
        {
            this.title = searchResult[0];
            this.overview = searchResult[1];
            //this.posterURLs.original = searchResult[2];
            //this.streamingInfo.netflix.us.link = searchResult[3];
        }
        public Result() { }

        /*******************************************************************************************************
         * Determines whether the Result is a moive by checking if the season cound is above 0. 
         * if seasons = 0, it is a movie, if not it is a series
         * RETURN: true if the Result is a movie
         *******************************************************************************************************/
        public bool isMovie()
        {
            bool movie = false;
            try
            {
                if (seasons >= 1)
                {

                }
                else
                {
                    movie = true;
                }
            }
            catch(Exception e)
            {
                movie = true;
            }
            return movie;
        }
    }
}
