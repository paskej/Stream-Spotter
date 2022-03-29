using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
	public class ProfileController
	{
		public ProfileController()
		{

		}

		public void CreateProfile(string profileName, ArrayList serviceList, int id)
		{
			Profile newProfile = new Profile(profileName, serviceList, id);
			//this is where the profile will be added to the database
		}

		public void RemoveProfile(string profileName)
		{
			//this is where the profile will be removed from the database
		}

		public Profile GetProfile(string profileName)
		{
			Profile found = new Profile();
			return found;
		}
	}
}
