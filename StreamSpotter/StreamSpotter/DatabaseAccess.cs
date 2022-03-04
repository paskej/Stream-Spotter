using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamSpotter
{
    
    class DatabaseAccess
    {
        private List<string> paths;
        private string profileName;
        private List<string> profileNames;
        private int index;

        public DatabaseAccess(string profileName)
        {
            this.paths = new List<string>();
            this.profileNames = new List<string>();
            this.profileName = profileName;
            index = 0;
        }

        public void addProfileDirectory(string profileName)
        {
            if(!Directory.Exists(@"C:Wishlists\Profiles\" + profileName))
            {
                Directory.CreateDirectory(@"C:Wishlists\Profiles\" + profileName);
            }
        }
        public void addJson(string profileName, string fileName)
        {
            if(!File.Exists(@"C:Wishlists\Profiles\" + profileName + fileName + ".json"))
            {
                File.Create(@"C:Wishlists\Profiles\" + profileName + fileName + ".json");
            }
        }

        public void addToWishlist(string profileName, Movie movie)
        {
            string path = @"C:Wishlists\Profiles\" + profileName + ".json";
            using (var tw = new StreamWriter(path, true))
            {
                string text = JsonConvert.SerializeObject(movie);
                tw.WriteLine(text);
                tw.Close();
            }
        }
      
        public Movie getMovie(string profileName, string movieName)
        {
            int i = getProfileIndex(profileName);
            string fileName = @"C:Wishlists\Profiles\" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var wishlist = JsonConvert.DeserializeObject<Wishlist>(json);
            return wishlist.Movie.ElementAt(0);
        }
        /*
        public string getMovieUrl()
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return movie.streamingInfo.netflix.us.link;
        }

        public string getMovieTitle()
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return movie.title;
        }

        public string getMovieOverview()
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return movie.overview;
        }

        public int getMovieRating()
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return movie.imdbRating;
        }

        public string getMovieBackdropPath()
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return movie.backdropPath;
        }

        public int getMovieYear()
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            return movie.year;
        }
        */
        private int getProfileIndex(string name)
        {
            int ind = -1;
            for(int i = 0; i < profileNames.Count; i++)
            {

                if(profileNames[i] == name)
                {
                    ind = i;
                }
            }
            return ind;
        }
        static void Main()
        {
            string json = File.ReadAllText("witcher.json");
            var movie = JsonConvert.DeserializeObject<Movie>(json);
            DatabaseAccess da = new DatabaseAccess("Joe");
            da.addProfileDirectory("Joe");
            da.addJson("Joe", "Joe");
            da.addToWishlist("Joe",movie);
            Movie back = JsonConvert.DeserializeObject<Movie>(@"Wishlists\Profiles\Joe.json");
            Console.WriteLine(back.title);
        }
    }
}
