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

namespace StreamSpotter
{
	/*******************************************************************************************************
     * IOManager is a console version of our system to see if our api search results worked originally
     *******************************************************************************************************/
	class IOManager
	{
		private bool end;
		private string input;
		private const string SERVICE = "netflix";
		private string entertainmentType;
		private string title;
		private string searchResults;
		private APIController apiController;
		/*******************************************************************************************************
         * Constructor to initialize objects
         *******************************************************************************************************/
		public IOManager()
		{
			end = false;
			apiController = new APIController();
		}
		/*******************************************************************************************************
         * Method to run the console program
         *******************************************************************************************************/
		public void run()
		{
			while(end == false)
			{
				bool valid = false;
				while(valid == false)
				{ 
					Console.WriteLine("The current version of this program can only search for movies and series on Netflix");
					Console.WriteLine("Would you like to search on Netflix?");
					Console.WriteLine("\n please input the corresponding character to for selection");
					Console.WriteLine("Y - yes");
					Console.WriteLine("N - no");
					input = Console.ReadLine();
					if (input.Equals("N"))
					{
						end = true;
						valid = true;
					}
					else if (input.Equals("Y"))
					{

						bool typeChosen = false;
						while (typeChosen == false)
						{
							Console.WriteLine("\n would you like to watch a movie or series");
							Console.WriteLine("\n please input the corresponding character to for selection");
							Console.WriteLine("M - movie");
							Console.WriteLine("S - series");
							input = Console.ReadLine();
							if (input.Equals("M"))
							{
								entertainmentType = "movie";
								typeChosen = true;
							}
							else if (input.Equals("S"))
							{
								entertainmentType = "series";
								typeChosen = true;
							}
							else
								Console.WriteLine("\nInvalid Input\n");
						}

						Console.WriteLine("Please enter the title you are looking for");
						title = Console.ReadLine();

						searchResults = apiController.FindMovieSync(entertainmentType, SERVICE, title);
						Console.WriteLine("\n" + searchResults + "\n");

						bool acceptable = false;
						while (acceptable == false)
						{
							Console.WriteLine("Would you like to search for another movie?");
							Console.WriteLine("\n please input the corresponding character to for selection");
							Console.WriteLine("Y - yes");
							Console.WriteLine("N - no");

							input = Console.ReadLine();
							if (input.Equals("N"))
							{
								end = true;
								acceptable = true;
							}
							else if (input.Equals("Y"))
							{
								acceptable = true;
							}
							else
								Console.WriteLine("\n" + "Invalid Input" + "\n");
						}
						valid = true;
					}
					else
						Console.WriteLine("\n" + "Invalid Input" + "\n");

				}
				
			}
		}
	}
}
