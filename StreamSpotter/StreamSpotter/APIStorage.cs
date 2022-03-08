using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
	class APIStorage
	{
		private const int MAX_HISTORY_LENGTH = 5;
		private ArrayList jsonlist;

		public APIStorage()
		{
			jsonlist = new ArrayList();
		}

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

	}
}
