using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    public class Movie
    {
        private string title;
        private string description;
        private string streamService;

        public Movie(string title,string description,string streamService)
        {
            this.title = title;
            this.description = description;
            this.streamService = streamService;
        }

        public string getTitle()
        {
            return title;
        }
        public string getDescription()
        {
            return description;
        }
        public string getStreamService()
        {
            return streamService;
        }
    }
}
