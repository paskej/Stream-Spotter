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

        public void addProfile(Profile p)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\ListofProfiles.json";
            if (!File.Exists(path))
            {
                FileStream file = File.Create(path);
                file.Close();
                ProfileList pl = new ProfileList();
                pl.list = new Profile[1];
                pl.list[0] = p;
                string text = JsonConvert.SerializeObject(pl);
                using(var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(text);
                    tw.Close();
                }
            }
            else
            {
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(path);
                ProfileList temp = new ProfileList();
                temp.list = new Profile[pl.list.Length + 1];
                temp.list[pl.list.Length] = p;
                string text = JsonConvert.SerializeObject(temp);
                using(var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(text);
                    tw.Close();
                }
            }
        }

        public void removeProfile(string profileName)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\ListofProfiles.json";
            if (File.Exists(path))
            {
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(File.ReadAllText(path));
                int l = pl.list.Length;
                int i = 0;
                if(l> 0)
                {
                    while(i < l)
                    {
                        if(pl.list[i].getProfileName() == profileName)
                        {
                            Profile[] temp = new Profile[l - 1];
                            for(int j = i; j < l-1; j++)
                            {
                                temp[j] = pl.list[j + 1];
                            }
                            pl.list = temp;
                            l--;
                            i--;
                        }
                        i++;
                    }
                }
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

        public void removeFromWishlist(string profileName, string listName, string imdbID)
        {
            int i = 0;
            RootObject tempRo = new RootObject();
            string path = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            if (File.Exists(path))
            {
                RootObject ro = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(path));
                while(i < ro.results.Length)
                {
                    if(ro.results[i].imdbID == imdbID)
                    {
                        tempRo.results = new Result[ro.results.Length - 1];
                        for(int j = 0; j < i; j++)
                        {
                            tempRo.results[j] = ro.results[j];
                        }
                        for(int j = i; j < ro.results.Length-1; j++)
                        {
                            tempRo.results[j] = ro.results[j + 1];
                        }
                        tempRo.results.CopyTo(ro.results, 0);//changes ro.results.Length to the new size, so the while loop still checks to see if it is out of bounds
                        i--;//checks the same index again, since it is actually a new movie
                    }
                    i++;
                }
                string text = JsonConvert.SerializeObject(ro);
                using(var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(text);
                    tw.Close();
                }
            }
        }

        public Result[] getWishlist(string profileName, string listName)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\" + profileName + "\\" + listName + ".json";
            if(File.Exists(path))
            {
                RootObject ro = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(path));
                if (ro != null)
                {
                    return ro.results;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
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
        
        public string getNetflixUrl(string profileName, string listName, string movieName)
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
        public string getDisneyUrl(string profileName, string listName, string movieName)
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
                return ro.results[i].streamingInfo.disney.us.link;
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
    }
}
