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
        private Recommendations recommendations;

        public DatabaseAccess()
        {
            if(!Directory.Exists(BASE_PATH + "\\Wishlists\\Profiles"))
            {
                Directory.CreateDirectory(BASE_PATH + "\\Wishlists\\Profiles");
            }
            recommendations = new Recommendations();
        }

        public void addProfileDirectory(int profileID)
        {
            if (!Directory.Exists(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID))
            {
                Directory.CreateDirectory(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID);
            }
        }
        public void addJson(int profileID, string fileName)
        {
            if (!File.Exists(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\" + fileName + ".json"))
            {
                FileStream file = File.Create(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\" + fileName + ".json");
                file.Close();
            }
            if (!File.Exists(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\recommendations.json"))
            {
                FileStream r = File.Create(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\recommendations.json");
                r.Close();
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
                if(p.getID() == -1)
                {
                    p.setID(generateID());
                }
                addProfileDirectory(p.getID());
                addJson(p.getID(), p.getID().ToString());              
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
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(File.ReadAllText(path));
                ProfileList temp = new ProfileList();
                temp.list = new Profile[pl.list.Length + 1];
                for(int i = 0; i < pl.list.Length; i++)
                {
                    temp.list[i] = pl.list[i];
                }
                if (p.getID() == -1)
                {
                    p.setID(generateID());
                }
                addProfileDirectory(p.getID());
                addJson(p.getID(), p.getID().ToString());
                temp.list[pl.list.Length] = p;
                string text = JsonConvert.SerializeObject(temp);
                using(var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(text);
                    tw.Close();
                }
            }
        }

        public void updateProfile(Profile profile)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\ListofProfiles.json";
            if(File.Exists(path))
            {
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(File.ReadAllText(path));
                int i = -1;
                for(int j = 0; j < pl.list.Length; j++)
                {
                    if(pl.list[j].getID() == profile.getID())
                    {
                        i = j;
                    }
                }
                if(i >= 0)
                {
                    pl.list[i].setProfileName(profile.getProfileName());
                    pl.list[i].setServies(profile.getServices());
                    string text = JsonConvert.SerializeObject(pl);
                    using (var tw = new StreamWriter(path, false))
                    {
                        tw.WriteLine(text);
                        tw.Close();
                    }
                }
            }
        }

        public void removeProfile(int profileID)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\ListofProfiles.json";
            if (File.Exists(path))
            {
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(File.ReadAllText(path));
                int l = pl.list.Length;
                int i = 0;
                if(l > 1)
                {
                    while(i < l)
                    {
                        if(pl.list[i].getID() == profileID)
                        {
                            Profile[] temp = new Profile[l - 1];
                            for(int j = 0; j < i; j++)
                            {
                                temp[j] = pl.list[j];
                            }
                            for (int j = i; j < l - 1; j++)
                            {
                                temp[j] = pl.list[j + 1];
                            }
                            pl.list = temp;
                            l--;
                            i--;
                            string profilePath = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID;
                            foreach(string f in Directory.GetFiles(profilePath))
                            {
                                File.Delete(f);
                            }
                            Directory.Delete(profilePath);
                        }
                        i++;
                    }
                    updateIds(pl);
                    using (StreamWriter tw = new StreamWriter(path, false))
                    {
                        tw.WriteLine(JsonConvert.SerializeObject(pl));
                    }
                }
                else if(profileID == pl.list[i].getID())
                {
                    pl.list = new Profile[0];
                    string profilePath = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID;
                    foreach (string f in Directory.GetFiles(profilePath))
                    {
                        File.Delete(f);
                    }
                    Directory.Delete(profilePath);
                    using (StreamWriter tw = new StreamWriter(path, false))
                    {
                        tw.WriteLine(JsonConvert.SerializeObject(pl));
                    }
                }
            }
        }

        public ProfileList getProfileList()
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\ListofProfiles.json";
            if(File.Exists(path))
            {
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(File.ReadAllText(path));
                return pl;
            }
            else
            {
                return null;
            }
        }

        public void addToWishlist(int profileID, string listName, Result movie)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\" + listName + ".json";
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

        public void removeFromWishlist(int profileID, string listName, string imdbID)
        {
            int i = 0;
            RootObject tempRo = new RootObject();
            string path = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\" + listName + ".json";
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
                        ro.results = tempRo.results;//changes ro.results.Length to the new size, so the while loop still checks to see if it is out of bounds
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

        public Result[] getWishlist(int profileID, string listName)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\" + listName + ".json";
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

        public void updateRecommendations(int profileID)
        {
            string recPath = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\recommendations.json";
            if (File.Exists(recPath))
            {
                Result[] wishlist = getWishlist(profileID, profileID.ToString());
                Result[] recs = recommendations.getRecommendations(wishlist, getProfileList().list[profileID].services);
                RootObject ro = new RootObject();
                ro.results = recs;
                string text = JsonConvert.SerializeObject(ro);
                using (StreamWriter tw = new StreamWriter(recPath, false))
                {
                    tw.WriteLine(text);
                    tw.Close();
                }
            }
        }

        public Result[] getRecommendations(int profileID)
        {
            string recPath = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\recommendations.json";
            Result[] results = null;
            if (File.Exists(recPath))
            {
                if (File.ReadAllText(recPath) != "")
                {

                    RootObject ro = JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(recPath));
                    results = ro.results;
                }
            }
            return results;
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
        public Result getMovie(int profileID, string listName, string movieName)
        {
            string fileName = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\" + listName + ".json";
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
        int generateID()
        {
            ProfileList profiles = getProfileList();
            if (profiles == null)
            {
                return 0;
            }
            else
            {
                return profiles.list.Length;
            }
        }
        void updateIds(ProfileList pl)
        {
            for(int i = 0; i < pl.list.Length; i++)
            {
                if(pl.list[i].getID() != i)
                {
                    string old = BASE_PATH + "\\Wishlists\\Profiles\\" + pl.list[i].getID();
                    string n = BASE_PATH + "\\Wishlists\\Profiles\\" + i;
                    int pathLen = old.Length;
                    Directory.CreateDirectory(n);
                    foreach(string f in Directory.GetFiles(old))
                    {
                        string fileName = f.Remove(0,pathLen);
                        File.Move(f,(n + fileName));
                    }
                    Directory.Delete(old);
                    pl.list[i].setID(i);
                }
            }

        }
    }
}
