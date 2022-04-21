using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
	public class ProfileList
	{
		public Profile[] list { get; set; }
	}
	public class Profile
	{
		private readonly string[] POSSIBLE_SERVICES = { "netflix", "disney" };
		public ArrayList services { get; set; }
		public string profileName { get; set; }
		public int id { get; set; }

		//default constructor
		public Profile()
		{
			profileName = null;
			services = new ArrayList();
			id = -1;
		}

		public Profile(string profileName)
		{
			this.profileName = profileName;
			services = new ArrayList();
			id = -1;
			for (int i = 0; i < POSSIBLE_SERVICES.Length; i++)
			{
				services[i] = POSSIBLE_SERVICES[i];
			}
		}

		public Profile(string profileName, ArrayList services)
		{
			this.profileName = profileName;
			services = new ArrayList();
			id = -1;
			for (int i = 0; i < services.Count; i++)
			{
				this.services[i] = services[i];
			}
		}

		//parameterized constructor
		public Profile(string profileName, ArrayList services, int id)
		{
			this.profileName = profileName;
			services = new ArrayList();
			this.id = id;
			for(int i = 0; i < services.Count; i++)
			{
				this.services[i] = services[i];
			}
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

		public string getProfileName()
		{
			return profileName;
		}

		public void setProfileName(string profileName)
		{
			this.profileName = profileName;
		}

		public ArrayList getServices()
		{
			return services;
		}

		public void setServies(ArrayList services2)
		{
			//if (services2 != null)
			//{
				services = new ArrayList();
				for (int i = 0; i < services2.Count; i++)
				{

					this.services.Add(services2[i]);
				}
			//}
		}

		public int getID()
		{
			return id;
		}

		public void setID(int id)
		{
			this.id = id;
		}
	}
}
