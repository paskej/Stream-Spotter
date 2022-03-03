using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    public class Root
    {
<<<<<<< Updated upstream
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
        public int age { get; set; }
        public string backdropPath { get; set; }
        public string imdbID { get; set; }
        public int imdbRating { get; set; }
        public string overview { get; set; }
        public int runtime { get; set; }
        public string title{ get; set; }
        public int year { get; set; }
        public string streamService { get; set; }
        public Streaminginfo streaminginfo { get; set; }
=======
        private int age { get; set; }
        private string backdropPath { get; set; }
        private string imdbID { get; set; }
        private int imdbRating { get; set; }
        private string overview { get; set; }
        private int runtime { get; set; }
        private string title{ get; set; }
        private int year { get; set; }
        private string streamService;
>>>>>>> Stashed changes

        public Movie(string title,string description,string streamService)
        {
            this.title = title;
            this.overview = description;
            this.streamService = streamService;
        }
        
        public string getTitle()
        {
            return title;
        }
        public string getOverview()
        {
            return overview;
        }
        public string getStreamService()
        {
            return streamService;
        }
    }
}
