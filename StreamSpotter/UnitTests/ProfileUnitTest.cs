using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamSpotter;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{ 
	[TestClass]
	public class ProfileUnitTest
	{
		Profile profile;


		//tests if a null value can be inserted into the streaming service list
		[TestMethod]
		public void AddService_NULL_FALSE()
		{
			profile = new Profile("john", 1);
			string nullCase = null;
			Assert.IsFalse(profile.AddService(nullCase));
		}


		//tests if an unavailable service can be inserted into the streaming service list
		[TestMethod]
		public void AddService_UNAVAILABLESERVICE_FALSE()
		{
			profile = new Profile("john", 1);
			string unavailableCase = "non-existantService";
			Assert.IsFalse(profile.AddService(unavailableCase));
		}

		//tests if netflix, an available streaming service can be inserted into the streaming service list
		[TestMethod]
		public void AddService_NETFLIX_TRUE()
		{
			profile = new Profile("john", 1);
			string netflix = "netflix";
			Assert.IsTrue(profile.AddService(netflix));
		}

		//tests if disney, an available streaming service can be inserted into the streaming service list
		[TestMethod]
		public void AddService_DISNEYPLUS_TRUE()
		{
			profile = new Profile("john", 1);
			string disney = "disney";
			Assert.IsTrue(profile.AddService(disney));
		}

		//tests if a null service can be removed
		[TestMethod]
		public void RemoveService_NULL_FALSE()
		{
			profile = new Profile("john", 1);
			string nullCase = null;
			Assert.IsFalse(profile.removeService(nullCase));
		}

		//tests if a service that isnt in the owned services list can be removed
		[TestMethod]
		public void RemoveService_NOTINLIST_FALSE()
		{
			profile = new Profile("john", 1);
			string notInListCase = "non-existantService";
			Assert.IsFalse(profile.removeService(notInListCase));
		}

		//tests if netflix, a service that is owned can be removed
		[TestMethod]
		public void RemoveService_REMOVENETFLIX_TRUE()
		{
			profile = new Profile("john", 1);
			string netflix = "netflix";
			string disney = "disney";
			profile.AddService(netflix);
			profile.AddService(disney);
			Assert.IsTrue(profile.removeService(netflix));
		}

		//tests if disney, a service that is owned can be removed
		[TestMethod]
		public void RemoveService_REMOVEDISNEYPLUS_TRUE()
		{
			profile = new Profile("john", 1);
			string netflix = "netflix";
			string disney = "disney";
			profile.AddService(netflix);
			profile.AddService(disney);
			Assert.IsTrue(profile.removeService(disney));
		}
	}
}
