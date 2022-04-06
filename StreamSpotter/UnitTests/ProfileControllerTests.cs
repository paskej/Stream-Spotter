using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamSpotter;
using System.Collections;

namespace UnitTests
{
	[TestClass]
	class ProfileControllerTests
	{
		ProfileController profileController;
		Profile pro1;

		[TestMethod]
		public void CreateProfile_True()
		{
			string name = "theName";
			ArrayList serv = new ArrayList();
			serv.Add("netflix");
			serv.Add("disney");
			profileController = new ProfileController();

			pro1 = profileController.CreateProfile(name, serv);
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


			Assert.Equals(pro1, found);
		}

		[TestMethod]
		public void RemoveProfile_True()
		{
			string name = "theName";
			ArrayList serv = new ArrayList();
			serv.Add("netflix");
			serv.Add("disney");

			profileController.CreateProfile(name, serv);
			profileController.RemoveProfile(0);
			Assert.IsNull(profileController.GetProfile(0));
		}

		[TestMethod]
		public void GetProfile_True()
		{
			string name = "theName";
			ArrayList serv = new ArrayList();
			serv.Add("netflix");
			serv.Add("disney");

			pro1 = profileController.CreateProfile(name, serv);

			Assert.Equals(pro1, profileController.GetProfile(0));
		}

		[TestMethod]
		public void getProfile_null_True()
		{
			Assert.IsNull(profileController.GetProfile(8));
		}


	}
}
