using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
	class Profile
	{
		private readonly string[] POSSIBLE_SERVICES = { "Nexflix", "Disney+" };
		private ArrayList services { get; set; }
		private string profileName { get; set; }
		private int id { get; set; }

		//default constructor
		public Profile()
		{
			profileName = null;
			id = 0;
		}

		//parameterized constructor
		public Profile(string profileName, int id)
		{
			this.profileName = profileName;
			this.id = id;
		}

		//attempts to add a service and if the service is added then returns true
		//if service is not a searchable service then it returns false
		public bool AddService(string serviceName)
		{
			if (serviceName != null)
			{
				for (int i = 0; i < POSSIBLE_SERVICES.Length; i++)
				{
					if (serviceName == POSSIBLE_SERVICES[i])
					{
						services.Add(serviceName);
						return true;
					}
				}
			}
			return false;
		}

		//attempts to remove a service and if the service is removed then returns true
		//if service is not in services then it returns false
		public bool removeService(string serviceName)
		{
			if (serviceName != null)
			{
				for (int i = 0; i < services.Count; i++)
				{
					if (serviceName == (string)services[i])
					{
						services.Remove(serviceName);
						return true;
					}
				}
			}
			return false;
		}
	}
}
