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
	public class ProfileController
	{
		public DatabaseAccess db;
		public bool listIsFull = false;
		public Profile[] fullProfileList;
		public const int TOTAL_PROFILES = 10;
		public int currNumProfiles = 0;
		public int currentProfileID = 0;

		/*******************************************************************************************************
				 * Constructor for the ProfileController
		 *******************************************************************************************************/
		public ProfileController()
		{
			db = new DatabaseAccess();
			fullProfileList = new Profile[TOTAL_PROFILES];
			ProfileList pl = db.getProfileList();
			if (pl != null && pl.list != null)
			{
				foreach (Profile p in db.getProfileList().list)
				{
					if (p.selected)
					{
						currentProfileID = p.id;
					}
				}
			}
		}

		/*******************************************************************************************************
         * creates a profile and adds it to the database
         * PARAMS: string profileName, string[] serviceList
         *******************************************************************************************************/
		public Profile CreateProfile(string profileName, string[] serviceList)
		{
			Profile created;
			ProfileList proList = db.getProfileList();
			if (proList != null && proList.list != null)
			{
				Profile[] fullProfileList = proList.list;

				if (fullProfileList.Length < TOTAL_PROFILES)
				{
					Profile newProfile = new Profile(profileName, serviceList);
					//this is where the profile will be added to the database
					db.addProfile(newProfile);
					created = newProfile;
					currNumProfiles++;
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

		/*******************************************************************************************************
         * removes a profile from the database
         * PARAM: int profileID
         *******************************************************************************************************/
		public void RemoveProfile(int profileID)
		{
			if (profileID > -1 && profileID < 10)
			{
				//this is where the profile will be removed from the database
				db.removeProfile(profileID);
			}
		}

		/*******************************************************************************************************
         * updates the information stored inside of the profile passed in
         * PARAM: Profile profile
         *******************************************************************************************************/
		public void UpdateProfile(Profile profile)
		{
			db.updateProfile(profile);
		}

		/*******************************************************************************************************
         * returns the profile associated with the ID passed in
         * PARAM: int profileID
         * RETURNS: Profile coresponding to profileID
         *******************************************************************************************************/
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

		/*******************************************************************************************************
         * returns true if the list is full
         * RETURNS: if list is full
         *******************************************************************************************************/
		public bool getListIsFull()
		{
			return listIsFull;
		}

		/*******************************************************************************************************
         * sets if the list is full
         * PARAM: bool Full
         *******************************************************************************************************/
		public void setListIsFull(bool Full)
		{
			listIsFull = Full;
		}

		/*******************************************************************************************************
         * returns the current number of profiles stored in the database
         * RETURNS: current number of profiles
         *******************************************************************************************************/
		public int getCurrNumProfiles()
        {
			return currNumProfiles;
        }

		/*******************************************************************************************************
         * returns the ID of the current profile
         * RETURNS: current profile ID
         *******************************************************************************************************/
		public int getCurrentProfile()
		{
			return currentProfileID;
		}

		/*******************************************************************************************************
         * sets the ID of the current profile
         *******************************************************************************************************/
		public void setCurrentProfile(int id)
		{
			currentProfileID = id;
		}

	}
}
