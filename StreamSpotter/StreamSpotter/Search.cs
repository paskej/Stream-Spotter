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
        private const int MOVIE_DATA_TYPES = 2;

        private APIStorage storage;
        private APIController apiController;


        public Search()
        {
            storage = new APIStorage();
            apiController = new APIController();

        }

        //for searching results

        public void searchResult(string title, string type)
        {
            //TODO
            //get services from profile
            string[] services = new string[1];
            services[0] = "netflix";

            RootObject ro1;
            if (services.Length > 0)
            {
                ro1 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(type, services[0], title));
                for(int i = 1; i < services.Length; i++)
                {
                    RootObject ro2 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(type, services[0], title));
                    //ro1 = merge.merge(r01, ro2);
                }
            }
            else
            {
                ro1 = JsonConvert.DeserializeObject<RootObject>(apiController.FindMovieSync(type, "netflix", title));
            }
            storage.AddJsonFile(JsonConvert.SerializeObject(ro1));
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
                //formattedSearchResults[i, j++] = ro.results[i].posterURLs.original;
                //formattedSearchResults[i, j++] = ro.results[i].streamingInfo.netflix.us.link;
            }

            return formattedSearchResults;
        }
    }
}
