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

		public void CreateProfile(string profileName, ArrayList serviceList)
		{
			Profile newProfile = new Profile(profileName, serviceList);
			//this is where the profile will be added to the database
		}
	}
}
