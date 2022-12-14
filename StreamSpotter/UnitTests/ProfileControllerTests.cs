using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamSpotter;
using System.Collections;

namespace UnitTests
{
	[TestClass]
	public class ProfileControllerTests
	{
		ProfileController profileController;
		Profile pro1;

		[TestMethod]
		public void CreateProfile_True()
		{
			string name = "theName";
			string[] serv = new string[2];
			serv[0] = "netflix";
			serv[1] = "disney";
			profileController = new ProfileController();

			//pro1 = profileController.CreateProfile(name, serv);
			ProfileList list = profileController.db.getProfileList();
			Profile found = null;
			if (list != null)
			{
				if (list.list != null)
				{
					for (int i = 0; i < list.list.Length; i++)
					{
						if (0 == list.list[i].getID())
						{
							found = list.list[i];
						}
					}
				}
			}


			Assert.AreEqual(pro1, found);
		}

		[TestMethod]
		public void RemoveProfile_True()
		{
			profileController = new ProfileController();
			string name = "theName";
			string[] serv = new string[2];
			serv[0] = "netflix";
			serv[1] = "disney";

			//profileController.CreateProfile(name, serv);
			profileController.RemoveProfile(0);
			Assert.IsNull(profileController.GetProfile(0));
		}

		[TestMethod]
		public void GetProfile_True()
		{
			profileController = new ProfileController();
			string name = "theName";
			string[] serv = new string[2];
			serv[0] = "netflix";
			serv[1] = "disney";

			pro1 = profileController.CreateProfile(name, serv);

			Assert.AreEqual(pro1.profileName, profileController.GetProfile(0).profileName);
		}

		[TestMethod]
		public void getProfile_null_True()
		{
			profileController = new ProfileController();
			Assert.IsNull(profileController.GetProfile(8));
		}


	}
}
