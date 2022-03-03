using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace StreamSpotter
{
	class APIController
	{
		private APIStorage storage;
		private string entertainmentType;
		private string service;
		private string title;
		private HttpClient client;
		private HttpRequestMessage request;
		

		public APIController()
		{
			client = new HttpClient();
			request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&genre=18&page=1&keyword=Witcher&output_language=en&language=en"),
				Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "e75519cffbmsh49f832e72968279p163a4bjsn8f381dfaa0ba" },
	},
			};
		}

		public void Change(string type, string theService, string theTitle)
		{
			entertainmentType = type;
			service = theService;
			title = theTitle;
			string theUri = "https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=" + service + "&type=" + entertainmentType + "&genre=18&page=1&keyword=" + title + "&output_language=en&language=en";
			request.RequestUri = new Uri(theUri);
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

		public string FindMovieSync()
		{
			string movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
			return movieResults;
		}
	}
}
