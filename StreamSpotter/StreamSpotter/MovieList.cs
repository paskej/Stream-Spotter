using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
    class MovieList
    {
        private List<Movie> movieList;
        Panel panel;

        public MovieList(Panel panel)
        {
            movieList = null;
            this.panel = panel;
        }

        //gather all information from json file to put into the movieList
        public void populateList()
        {

        }

        public void printList()
        {
            //adds the list to the panel
            foreach(Movie movie in movieList)
            {
                
            }
        }
    }
}
