//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{

	public class APIStorage
	{
		private const int MOST_RECENT = 0;
		private const int MAX_HISTORY_LENGTH = 5;
		private ArrayList jsonlist;

		/*******************************************************************************************************
         * Constructor
         *******************************************************************************************************/
		public APIStorage()
		{
			jsonlist = new ArrayList();
		}

		/*******************************************************************************************************
         * Method to add a json file to the database
         * PARAMS: string file
         *******************************************************************************************************/
		public void AddJsonFile(string file)
		{
			if(jsonlist.Count < MAX_HISTORY_LENGTH)
			{
				jsonlist.Add(file);
			}
			else if(jsonlist.Count <= MAX_HISTORY_LENGTH)
			{
				jsonlist.RemoveAt(MAX_HISTORY_LENGTH - 1);
				jsonlist.Add(file);
			}
		}

		/*******************************************************************************************************
         * Method to return the most recent JSON file
         * RETURN: contents of json as a string
         *******************************************************************************************************/
		public string getMostRecent()
		{
			return (string)jsonlist[MOST_RECENT];
		}
	}
}
