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
		public DatabaseAccess db;
		public bool listIsFull = false;
		public Profile[] fullProfileList;
		public const int TOTAL_PROFILES = 10;
		public int currentProfileID = -1;

		public ProfileController()
		{
			db = new DatabaseAccess();
		}

		public Profile CreateProfile(string profileName, ArrayList serviceList)
		{
			Profile created;
			ProfileList proList = db.getProfileList();
			if (proList != null && proList.list != null)
			{
				Profile[] fullProfileList = proList.list;

				if (fullProfileList.Length < TOTAL_PROFILES - 1)
				{
					Profile newProfile = new Profile(profileName, serviceList);
					//this is where the profile will be added to the database
					db.addProfile(newProfile);
					created = newProfile;
				}
				else
				{
					listIsFull = true;
					created = null;
				}
			}
			else
			{
				
				Profile newProfile = new Profile(profileName, serviceList);
				db.addProfile(newProfile);
				created = newProfile;
			}
			return created;
		}

		public void RemoveProfile(int profileID)
		{
			if (profileID > -1 && profileID < 10)
			{
				//this is where the profile will be removed from the database
				db.removeProfile(profileID);
			}
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

		public int getCurrentProfile()
		{
			return currentProfileID;
		}

		public void setCurrentProfile(int id)
		{
			currentProfileID = id;
		}

	}
}
