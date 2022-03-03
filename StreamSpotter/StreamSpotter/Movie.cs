using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    public class Movie
    {
        private int age { get; set; }
        private string backdropPath { get; set; }
        private string imdbID { get; set; }
        private int imdbRating { get; set; }
        private string overview { get; set; }
        private int runtime { get; set; }
        private string title{ get; set; }
        private int year { get; set; }
        private string streamService;

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
