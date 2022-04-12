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
<<<<<<< Updated upstream:StreamSpotter/StreamSpotter/ProfileController.cs
		private DatabaseAccess db;
		private bool listIsFull = false;
		Profile[] fullProfileList;
=======
		public DatabaseAccess db;
		public bool listIsFull = false;
		public Profile[] fullProfileList;
		public const int TOTAL_PROFILES = 10;
		public int currentProfileID = 0;
>>>>>>> Stashed changes:StreamSpotter/StreamSpotter/Control/ProfileController.cs

		public ProfileController()
		{
			db = new DatabaseAccess();
		}

		public void CreateProfile(string profileName, ArrayList serviceList)
		{
			
			ProfileList proList = db.getProfileList();
			if (proList != null && proList.list != null)
			{
				Profile[] fullProfileList = proList.list;

				if (fullProfileList.Length <= 10)
				{
					Profile newProfile = new Profile(profileName, serviceList);
					//this is where the profile will be added to the database
					db.addProfile(newProfile);
				}
				else
				{
					listIsFull = true;
				}
			}
			else
			{
				
				Profile newProfile = new Profile(profileName, serviceList);
				db.addProfile(newProfile);
			}
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

		public bool getListIsFull()
		{
			return listIsFull;
		}

		public void setListIsFull(bool Full)
		{
			listIsFull = Full;
		}
	}
}
