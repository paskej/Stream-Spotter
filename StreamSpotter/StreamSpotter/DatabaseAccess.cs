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
        private static int MAX_USERS = 4;
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

        public Boolean createJson(Movie movie)
        {
            string JSONresult = JsonConvert.SerializeObject(movie); 
            string path = @"~\Wishlists\Profiles\" + profileName;
            if (File.Exists(path))
            {
                return true;
            }
            else if(!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                    profileNames[index] = profileName;
                    index++;
                    return true;
                }
            }
            return false;
        }

        public Boolean createJson(List<Movie> wishlist)
        {
            List<string> results = new List<string>();
            string path = @"~\Wishlists\Profiles\" + profileName;
            if (File.Exists(path))
            {
                File.Delete(path);
                using (var tw = new StreamWriter(path, true))
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        tw.WriteLine(results[i].ToString());
                    }
                    tw.Close();
                }
                return true;
            }
            else if(!File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        tw.WriteLine(results[i].ToString());
                    }
                    tw.Close();
                }
                index++;
                return true;
            }
            return false;
        }

        public Movie getMovie(string profileName, string movieName)
        {
            int i = getProfileIndex(profileName);
            string fileName = @"~/Wishlists/Profiles/" + profileNames[i];
            string json = File.ReadAllText(fileName);
            var wishlist = JsonConvert.DeserializeObject<Wishlist>(json);
            return wishlist.Movie.ElementAt(0);
        }
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
    }
}
