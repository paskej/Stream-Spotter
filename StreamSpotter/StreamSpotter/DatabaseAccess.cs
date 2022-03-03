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

        class tempMovie
        {
            private int age { get; set; }
            private string backdropPath { get; set; }
            private string imdbID { get; set; }
            private int imdbRating { get; set; }
            private string overview { get; set; }
            private int runtime { get; set; }
            private string title { get; set; }
            private int year { get; set; }
        }
        public string parseMovie()
        {
            int i = getProfileIndex();
            string path = @"~/Wishlists/Profiles/" + profileNames[i];
            var movie = JavaScriptSerializer().Deserialize<Movie>()
        }

        private object JavaScriptSerializer()
        {
            throw new NotImplementedException();
        }

        private int getProfileIndex()
        {
            int ind = -1;
            for(int i = 0; i < profileNames.Count; i++)
            {
                if(profileNames[i] == profileName)
                {
                    ind = i;
                }
            }
            return ind;
        }
    }
}
