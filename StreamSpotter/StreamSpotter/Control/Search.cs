//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamSpotter
{
    // -------------------------------------------------------------------
    // Search sends the necesary information required to get results from the API.
    // It also retrieves any results sent by the API.
    // -------------------------------------------------------------------
    class Search
    {
        private const int MOVIE_DATA_TYPES = 4;
        private const string MOVIE = "movie";
        private const string SERIES = "series";

        private APIStorage storage;
        private APIController apiController;
        private Merge merge;

        /// <summary>
        /// Search class constructor. Sets up all needed objects.
        /// </summary>
        public Search()
        {
            storage = new APIStorage();
            apiController = new APIController();
            merge = new Merge();
        }

        //for searching results
        /// <summary>
        /// Interfaces with APIController to search all relevent streaming
        /// services for movies and series that match the specified 
        /// title.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="services"></param>
        public void searchResult(string title, string[] services)
        {
            RootObject ro1, ro2;
            if (services.GetLength(0) > 0)
            {
                //-----------------------------------------------------
                // Searches for movies, then series, then merges both lists into one
                //-----------------------------------------------------
                ro1 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(MOVIE, services[0], title));
                ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(SERIES, services[0], title));
                ro1 = merge.mergeLists(ro1, ro2);
                for(int i = 1; i < services.Length; i++)
                {
                    ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(MOVIE, services[i], title));
                    ro1 = merge.mergeLists(ro1, ro2);
                    ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(SERIES, services[i], title));
                    ro1 = merge.mergeLists(ro1, ro2);
                }
            }
            //-----------------------------------------------------
            // By default, just searching Netflix
            //-----------------------------------------------------
            else
            {
                ro1 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(MOVIE, "netflix", title));
                ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(SERIES, "netflix", title));
                ro1 = merge.mergeLists(ro1, ro2);
            }
            storage.AddJsonFile(JsonConvert.SerializeObject(ro1));
        }

        /// <summary>
        /// Determines what streaming service the Result is on and then
        /// navigates to the path of the link and returns it as a string.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="ro"></param>
        /// <returns>streaming link as a string</returns>
        public string getStreamingLink(int index, RootObject ro)
        {
            if(ro.results[index].streamingInfo.netflix != null)
            {
                return ro.results[index].streamingInfo.netflix.us.link;
            }
            else if(ro.results[index].streamingInfo.disney != null)
            {
                return ro.results[index].streamingInfo.disney.us.link;
            }
            else if(ro.results[index].streamingInfo.hulu != null)
            {
                return ro.results[index].streamingInfo.hulu.us.link;
            }
            else if(ro.results[index].streamingInfo.prime != null)
            {
                return ro.results[index].streamingInfo.prime.us.link;
            }
            else
            {
                return "null";
            }
        }

        /// <summary>
        /// Gets a json of the most recent search and then converts it
        /// into a list of Result.
        /// </summary>
        /// <returns>The most recent search results as a list of Result</returns>
        public Result[] getSearchResults()
        {
            string searchResult = storage.getMostRecent();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(searchResult);
            Result[] results = ro.results;
            return results;
        }
    }
}
