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
		private DatabaseAccess db;
		public ProfileController()
		{
			db = new DatabaseAccess();
		}

		public void CreateProfile(string profileName, ArrayList serviceList)
		{
			Profile newProfile = new Profile(profileName, serviceList);
			//this is where the profile will be added to the database
			db.addProfile(newProfile);
		}

		public void RemoveProfile(int profileID)
		{
			//this is where the profile will be removed from the database
			db.removeProfile(profileID);
		}

		public void UpdateProfile(Profile profile)
		{
			db.updateProfile(profile);
		}

		public Profile GetProfile(int profileID)
		{
			ProfileList list = db.getProfileList();
			Profile found = null;
			if(list != null)
			{
				if(list.list != null)
				{
					for(int i = 0; i < list.list.Length; i++)
					{
						if(profileID == list.list[i].getID())
						{
							found = list.list[i];
						}
					}
				}
			}
			return found;
		}
	}
}
