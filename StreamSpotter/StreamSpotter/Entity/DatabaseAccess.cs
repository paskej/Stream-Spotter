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
    /*******************************************************************************************************
     * DatabaseAccess is the only way to access or change what is stored in the database for this 
     * program (JSON files). The database stores profiles, wishlists, and recommendations for each
     * profile.
     *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Creates a folder in the computer's file system for the given profile ID.
         * PARAMS: int profileID, ID of the profile to have folder made for
         *******************************************************************************************************/
        public void addProfileDirectory(int profileID)
        {
            if (!Directory.Exists(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID))
            {
                Directory.CreateDirectory(BASE_PATH + "\\Wishlists\\Profiles\\" + profileID);
            }
        }
        /*******************************************************************************************************
         * Creates a .json file for a profiles wishlist and recommendations
         * PARAMS: int profileID, profile to add .json files for
         *                 string fileName, name of the wishlist to be added
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Adds a profile to the database. Generates directories, .json files, and an unique ID for the profile.
         * PARAMS: Profile p, Profile to be added to the database
         *******************************************************************************************************/
        public void addProfile(Profile p)
        {
            string path = BASE_PATH + "\\Wishlists\\Profiles\\ListofProfiles.json";//This file stores the Profile classes
            
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
                string text = JsonConvert.SerializeObject(pl);//converts an object into a .json string
                using(var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(text);
                    tw.Close();
                }
            }
            else
            {
                ProfileList pl = JsonConvert.DeserializeObject<ProfileList>(File.ReadAllText(path));//reads a string from the file on path, and converts it to a ProfileList
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
        /*******************************************************************************************************
         *Updates the given profile in the database, if it is in the database
         * PARAMS: Profile profile, Profile to be updated in the database. Everything can be changed except
         *                                        for the profile's ID.
         *******************************************************************************************************/
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
                    pl.list[i].selected = profile.selected;
                    string text = JsonConvert.SerializeObject(pl);
                    using (var tw = new StreamWriter(path, false))
                    {
                        tw.WriteLine(text);
                        tw.Close();
                    }
                }
            }
        }
        /*******************************************************************************************************
         * Removes a profile from the database. All profiles already stored after the deleted profile are
         * shifted over so there is not an empty hole in the array.
         * PARAMS: int profileID, ID of the profile to be deleted.
         *******************************************************************************************************/
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
                            foreach(string f in Directory.GetFiles(profilePath))//All files in the directory must be deleted before the directory can be deleted
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
                else if(profileID == pl.list[i].getID())//case if the profile is the only one in the list
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
        /*******************************************************************************************************
         * Retrieves the list of Profiles from the database
         * RETURN: ProfileList class which contains an array of Profiles stored in the database
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Adds a given Result to the desired stored wishlist
         * PARAMS: int profileID, ID of the profile which owns the wishlist
         *                 string listName, name of the wishlist
         *                 Result movie, Result to be added to the wishlist
         *******************************************************************************************************/
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
                        tw.Write("],\"total_pages\":1}");//need to add total pages since this is the format the API gives us
                        tw.Close();
                    }
                }
            }
        }
        /*******************************************************************************************************
         * Removes the disired Result from the correct wishlist
         * PARAMS: int profileID, ID of the profile which owns the wishlist
         *                 string listName, name of the wishlist
         *                 string imdbID, Imdb ID of the Result to be removed (did not use name in case of duplicate
         *                 names (EX: Avatar(Blue people) and Avatar(Element bending)).
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Retrieves the correct wishlist from the database
         * PARAMS: int profileID, ID of the profile which owns the wishlist
         *                 string listName,  name of the wishlist
         * RETURN: Array of Results which contains the stored wishlist
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Calls the Recommendations class for the given profile and stores those recommendations in the
         * profile's directory
         * PARAMS: int profileID, ID of the profile to be updated
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Allows another class to store recommendations without making a call to the API
         * PARAMS: int profileID, ID of the profile for the recommendations to be stored under
         *                 Result[] rec, Array of results containing the recommendations to be stored
         *******************************************************************************************************/
        public void importRecommendations(int profileID, Result[] rec)
        {
            string recPath = BASE_PATH + "\\Wishlists\\Profiles\\" + profileID + "\\recommendations.json";
            FileStream file = File.Create(recPath);
            file.Close();
            RootObject ro = new RootObject();
            ro.results = rec;
            string text = JsonConvert.SerializeObject(ro);
            using (StreamWriter tw = new StreamWriter(recPath, false))
            {
                tw.WriteLine(text);
                tw.Close();
            }

        }
        /*******************************************************************************************************
         * Retrieves the recommendations for a given profile from the database.
         * PARAMS: int profileID, ID of the profile you need recommendations for
         * RETURN: Array of Results containing the stored recommendations
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Finds the index of a movie in a RootObject
         * PARAMS: RootObject ro, RootObject containing the movie
         *                 string movieName, name of the movie you want to find
         * RETURN: index of the movie in ro's list, -1 if not found
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Retrieves a movie from any wishlist the database
         * PARAMS: int profileID, ID of the profile which owns the wishlist
         *                 string listName, name of the wishlist
         *                 string movieName, name of the movie to be retrieved
         * RETURN: The Result in the wishlist with the same name as movieName
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Generates an unique ID for a new profile
         * RETURN: The id to be used for the profile
         *******************************************************************************************************/
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
        /*******************************************************************************************************
         * Updates IDs of all profiles in the ProfileList. If there is a gap in profile IDs (like skipping from 3 to 5),
         * shifts all necessary IDs to close the gap, as well as moving the files in the stored database.
         * PARAMS: ProfileList pl, ProfileList containing the array of profiles to be updated
         *******************************************************************************************************/
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
                        if (fileName == "\\" + (i + 1).ToString() + ".json")
                        {
                            File.Move(f, (n + "\\" + i + ".json"));
                        }
                        else
                        {
                            File.Move(f, (n + fileName));
                        }
                    }
                    Directory.Delete(old);
                    pl.list[i].setID(i);
                }
            }

        }
    }
}
