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

		/// <summary>
		/// Constructor for APIController. Sets up the HTTP client and
		/// creates a default HTTP request message along with all available
		/// API keys.
		/// </summary>
		public APIController()
		{
			
			client = new HttpClient();

			keys = new string[5];
			keys[0] = "bc845cec13msh18fba8e190a0fd2p177163jsne160d9e55201";
			keys[1] = "c59f8bd33amshfbc0ea2813f2495p12fdbajsneaf23d8c829a";
			keys[2] = "a98a6b35fbmsh46d53f60be5bcdcp1fda1fjsn4ecde5959c3f";
			keys[3] = "304c4fbc80msh73d17a1513320bfp14d0b6jsn1fe16b2c3fd5";
			keys[4] = "caa3e586bamsh32546b6ad7ffb10p152ce9jsn604b15f84c0c";
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

		/// <summary>
		/// Creats a new HTTP Request message that will be used to send
		/// the API a request. Sets all needed API information here.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="theService"></param>
		/// <param name="theTitle"></param>
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

		/// <summary>
		/// Asynchronous call to the API that requests the results of
		/// a search.
		/// </summary>
		/// <returns></returns>
		public async Task<string> MakeRequestAsync()
		{

			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return body;
			}

		}

		/// <summary>
		/// Takes a type of result (movie or show), the service to search,
		/// and the title for the search as a synchronous call. It then 
		/// makes an ascynchronous call that acts like 
		/// synchronous call to the outside program and returns the result
		/// as a string.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="theService"></param>
		/// <param name="theTitle"></param>
		/// <returns>json string of results</returns>
		public string FindMovieSync(string type, string theService, string theTitle)
		{
			Change(type, theService, theTitle);
			string movieResults = "";

			bool invalid = true;
			do
			{
				try
				{
					//-------------------------------------------------
					// Calls asynchronous function as a synchronous function
					//-------------------------------------------------
					movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
					invalid = false;
				}
				//-------------------------------------------------
				// If the call to the API fails, use the next API key
				//-------------------------------------------------
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

			currentKey = 0;
			//storage.AddJsonFile(movieResults);
			return movieResults;

		}
		
	}
}
