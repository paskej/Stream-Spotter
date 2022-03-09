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

    public class DatabaseAccess
    {
        private static string BASE_PATH = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

        public DatabaseAccess() {}

        public void addProfileDirectory(string profileName)
        {
            if (!Directory.Exists(BASE_PATH + "\\Wishlists\\Profiles\\" + profileName))
            {
                Directory.CreateDirectory(BASE_PATH + "\\Wishlists\\Profiles\\" + profileName);
            }
        }
        public void addJson(string profileName, string fileName)
        {
            if (!File.Exists(BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + fileName + ".json"))
            {
                FileStream file = File.Create(BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + fileName + ".json");
                file.Close();
            }
        }

        public void addToWishlist(string profileName, string listName, Result movie)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            if (File.Exists(path))
            {
                RootObject ro = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(path));
                if (ro != null)
                {
                    int l = ro.results.Length;
                    Result[] temp = new Result[l + 1];
                    ro.results.CopyTo(temp, 0);
                    temp[l] = movie;
                    ro.results = temp;
                    string text = JsonConvert.SerializeObject(ro);
                    using (var tw = new StreamWriter(path, false))
                    {
                        tw.WriteLine(text);
                        tw.Close();
                    }
                }
                else
                {
                    string text = JsonConvert.SerializeObject(movie);
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.Write("{\"results\" :[");
                        tw.Write(text);
                        tw.Write("],\"total_pages\":1}");
                        tw.Close();
                    }
                }
            }
        }
        public int getMovieIndex(RootObject ro, string movieName)
        {
            int temp = -1;
            for (int i = 0; i < ro.results.Length; i++)
            {
                if (ro.results[i].title == movieName)
                {
                    temp = i;
                }
            }
            return temp;
        }
        /*
        public int getMovieIndex(string profileName, string movieName)
        {

        }
        */
        public Result getMovie(string profileName, string listName, string movieName)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            string json = File.ReadAllText(fileName);
            RootObject wishlist = JsonConvert.DeserializeObject<RootObject>(json);
            int i = getMovieIndex(wishlist, movieName);
            if (i < 0)
            {
                return null;
            }
            else
            {
                return wishlist.results[0];
            }
        }
        
        public string getMovieUrl(string profileName, string listName, string movieName)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            string json = File.ReadAllText(fileName);
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
            int i = getMovieIndex(ro, movieName);
            if (i < 0)
            {
                return null;
            }
            else
            {
                return ro.results[i].streamingInfo.netflix.us.link;
            }
        }
        public string getPosterUrl(string profileName, string listName, string movieName)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            string json = File.ReadAllText(fileName);
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
            int i = getMovieIndex(ro, movieName);
            if (i < 0)
            {
                return null;
            }
            else
            {
                return ro.results[i].posterURLs.original;
            }
        }
        public int getImdbRating(string profileName, string listName, string movieName)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            string json = File.ReadAllText(fileName);
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
            int i = getMovieIndex(ro, movieName);
            if (i < 0)
            {
                return -1;
            }
            else
            {
                return ro.results[i].imdbRating;
            }
        }
        public string getMovieTitle(string profileName, string listName, int index)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            string json = File.ReadAllText(fileName);
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
            return ro.results[index].title;
        }
        

        public string getMovieOverview(string profileName, string listName, string movieName)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            string json = File.ReadAllText(fileName);
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
            int i = getMovieIndex(ro, movieName);
            if(i < 0)
            {
                return null;
            }
            else
            {
                return ro.results[i].overview;
            }
        }
        /*
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
       /* static void Main()
        {
            Console.WriteLine(BASE_PATH);
            string json = File.ReadAllText("breakingbad.json");
            Console.WriteLine(json);
            var movies = JsonConvert.DeserializeObject<RootObject>(json);
            //var movie = movies.Movie.ElementAt(0);
            Console.WriteLine(movies.results[0].title);
            DatabaseAccess da = new DatabaseAccess();
            da.addProfileDirectory("Joe");
            da.addJson("Joe", "Joe");
            da.addToWishlist("Joe", movies.results[0]);
            string jsonBack = File.ReadAllText(BASE_PATH + "\\Wishlists\\Profiles\\Joe\\Joe.json");
            RootObject back = JsonConvert.DeserializeObject<RootObject>(jsonBack);
            Console.WriteLine(back.results[0].title);
        }
        */
    }
}
