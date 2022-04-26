using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StreamSpotter
{
    class Search
    {
        private const int MOVIE_DATA_TYPES = 4;
        private const string MOVIE = "movie";
        private const string SERIES = "series";

        private APIStorage storage;
        private APIController apiController;
        private Merge merge;


        public Search()
        {
            storage = new APIStorage();
            apiController = new APIController();
            merge = new Merge();
        }

        //for searching results

        public void searchResult(string title, string[] services)
        {
            RootObject ro1, ro2;
            if (services.GetLength(0) > 0)
            {
                ro1 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(MOVIE, services[0], title));
                for(int i = 1; i < services.Length; i++)
                {
                    ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(MOVIE, services[i], title));
                    ro1 = merge.mergeLists(ro1, ro2);
                    ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(SERIES, services[i], title));
                    ro1 = merge.mergeLists(ro1, ro2);
                }
            }
            else
            {
                ro1 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(MOVIE, "netflix", title));
                ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(SERIES, "netflix", title));
                ro1 = merge.mergeLists(ro1, ro2);
            }
            storage.AddJsonFile(JsonConvert.SerializeObject(ro1));
        }

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
            else
            {
                return "null";
            }
        }

        public Result[] getSearchResults()
        {
            string searchResult = storage.getMostRecent();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(searchResult);
            Result[] results = ro.results;
            return results;
        }

        //for getting the searched item and send to the api
        //How data is returned:
        //[title, description, poster url, netflix url]
        public string[,] getSearchResult()
        {
            string searchResult = storage.getMostRecent();
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(searchResult);
            int numOfResults = ro.results.Length;
            string[,] formattedSearchResults = new string[numOfResults, MOVIE_DATA_TYPES];

            for (int i = 0; i < numOfResults; i++)
            {
                int j = 0;
                formattedSearchResults[i, j++] = ro.results[i].title;
                formattedSearchResults[i, j++] = ro.results[i].overview;

                if(ro.results[i].posterURLs.original != null)
                {
                    formattedSearchResults[i, j++] = ro.results[i].posterURLs.original;

                }
                else
                {
                    formattedSearchResults[i, j++] = "https://images.saymedia-content.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:eco%2Cw_1200/MTc0NDk1MzYxOTUwMjk1NDAw/the-true-importance-of-tumbleweeds.jpg";
                }

                formattedSearchResults[i, j++] = getStreamingLink(i, ro);
            }

            return formattedSearchResults;
        }
    }
}
