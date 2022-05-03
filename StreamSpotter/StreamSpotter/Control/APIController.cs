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
		private string entertainmentType;
		private string service;
		private string title;
		private HttpClient client;
		private HttpRequestMessage request;
		private string[] keys;
		private int currentKey;

		public APIController()
		{
			
			client = new HttpClient();

			keys = new string[4];
			keys[0] = "bc845cec13msh18fba8e190a0fd2p177163jsne160d9e55201";
			keys[1] = "c59f8bd33amshfbc0ea2813f2495p12fdbajsneaf23d8c829a";
			keys[2] = "a98a6b35fbmsh46d53f60be5bcdcp1fda1fjsn4ecde5959c3f";
			keys[3] = "304c4fbc80msh73d17a1513320bfp14d0b6jsn1fe16b2c3fd5";
			currentKey = 0;

			request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&keyword=shrek&page=1&output_language=en&language=en"),
				Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", keys[0] },
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
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=" + service + "&type=" + entertainmentType + "&keyword=" + title + "&page=1&output_language=en&language=en"),
				Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", keys[0] },
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
			string movieResults = "";

			bool invalid = true;
			do
			{
				try
				{
					movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
					invalid = false;
				}
				catch (Exception e)
				{
					
					currentKey++;
					request = new HttpRequestMessage
					{
						Method = HttpMethod.Get,
						RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=" + service + "&type=" + entertainmentType + "&keyword=" + title + "&page=1&output_language=en&language=en"),
						Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", keys[currentKey] },
	},
					};
				}
			} while (invalid);
			
			//storage.AddJsonFile(movieResults);
			return movieResults;

		}
		
	}
}
