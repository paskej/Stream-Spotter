using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;



namespace StreamSpotter
{
	public class APIController
	{
		const int MOVIE_DATA_TYPES = 2;
		public APIStorage storage;
		private string entertainmentType;
		private string service;
		private string title;
		private HttpClient client;
		private HttpRequestMessage request;


		public APIController()
		{
			storage = new APIStorage();
			client = new HttpClient();
			request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&genre=18&page=1&keyword=Witcher&output_language=en&language=en"),
				Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "bc845cec13msh18fba8e190a0fd2p177163jsne160d9e55201" },
	},
			};
		}

		public void Change(string type, string theService, string theTitle)
		{
			entertainmentType = type;
			service = theService;
			title = theTitle;

			title = title.Replace(" ", "%20");

			request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=" + service + "&type=" + entertainmentType + "&genre=18&page=1&keyword=" + title + "&output_language=en&language=en"),
				Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "bc845cec13msh18fba8e190a0fd2p177163jsne160d9e55201" },
	},
			};
		}

		public async Task<string> MakeRequestAsync()
		{

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return body;
			}

		}

		public string FindMovieSync(string type, string theService, string theTitle)
		{
			Change(type, theService, theTitle);
			string movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
			storage.AddJsonFile(movieResults);
			return movieResults;

		}


		//How data is returned:
		//[title, description, poster url, netflix url]
		public string[,] getSearchResult()
        {
			string searchResult = storage.getMostRecent();
			RootObject ro = JsonConvert.DeserializeObject<RootObject>(searchResult);
			int numOfResults = ro.results.Length;
			string[,] formattedSearchResults = new string[numOfResults,MOVIE_DATA_TYPES];
			
			for(int i = 0; i < numOfResults; i++)
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
