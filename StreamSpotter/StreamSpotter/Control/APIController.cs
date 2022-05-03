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


		public APIController()
		{
			
			client = new HttpClient();
			request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&keyword=shrek&page=1&output_language=en&language=en"),
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
				RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=" + service + "&type=" + entertainmentType + "&keyword=" + title + "&page=1&output_language=en&language=en"),
				Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "c59f8bd33amshfbc0ea2813f2495p12fdbajsneaf23d8c829a" },
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

			try
            {
				movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
			}
			catch(Exception e)
            {
				request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&keyword=shrek&page=1&output_language=en&language=en"),
					Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "bc845cec13msh18fba8e190a0fd2p177163jsne160d9e55201" },
	},
				};
				try
                {
					movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
				}
				catch(Exception e1)
                {
					request = new HttpRequestMessage
					{
						Method = HttpMethod.Get,
						RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&keyword=shrek&page=1&output_language=en&language=en"),
						Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "c59f8bd33amshfbc0ea2813f2495p12fdbajsneaf23d8c829a" },
	},
					};
                    try
                    {
						movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
					}
					catch(Exception e2)
                    {
						request = new HttpRequestMessage
						{
							Method = HttpMethod.Get,
							RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&keyword=shrek&page=1&output_language=en&language=en"),
							Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "a98a6b35fbmsh46d53f60be5bcdcp1fda1fjsn4ecde5959c3f" },
	},
						};
                        try
                        {
							movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
						}
						catch(Exception e3)
						{
							request = new HttpRequestMessage
							{
								Method = HttpMethod.Get,
								RequestUri = new Uri("https://streaming-availability.p.rapidapi.com/search/basic?country=us&service=netflix&type=movie&keyword=shrek&page=1&output_language=en&language=en"),
								Headers =
	{
		{ "x-rapidapi-host", "streaming-availability.p.rapidapi.com" },
		{ "x-rapidapi-key", "304c4fbc80msh73d17a1513320bfp14d0b6jsn1fe16b2c3fd5" },
	},
							};
                            try
                            {
								movieResults = Task.Run(async () => await MakeRequestAsync()).Result;
							}
							catch(Exception e4)
                            {
								//hopefully it doesn't get to here otherwise rip
                            }
						}
					}
				}
			}
			//storage.AddJsonFile(movieResults);
			return movieResults;

		}
		
	}
}
