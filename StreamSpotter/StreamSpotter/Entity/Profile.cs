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
		public string[] services { get; set; }
		public string profileName { get; set; }
		public int id { get; set; }

		//default constructor
		public Profile()
		{
			profileName = null;
			services = new string[0];
			id = -1;
		}

		public Profile(string profileName)
		{
			this.profileName = profileName;
			services = new string[POSSIBLE_SERVICES.Length];
			id = -1;
			for (int i = 0; i < POSSIBLE_SERVICES.Length; i++)
			{
				services[i] = POSSIBLE_SERVICES[i];
			}
		}

		public Profile(string profileName, string[] services)
		{
			this.profileName = profileName;
			this.services = new string[services.Length];
			id = -1;
			for (int i = 0; i < services.Length; i++)
			{
				this.services[i] = services[i];
			}
		}

		//parameterized constructor
		public Profile(string profileName, string[] services, int id)
		{
			this.profileName = profileName;
			services = new string[services.Length];
			this.id = id;
			for(int i = 0; i < services.Length; i++)
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
						if (services != null && !inServices(serviceName))
						{
							string[] temp = new string[services.Length + 1];
							for (int j = 0; j < services.Length; j++)
							{
								temp[j] = services[j];
							}
							temp[services.Length] = serviceName;
							services = temp;
						}
                        else
                        {
							services = new string[1];
							services[0] = serviceName;
                        }
						return true;
					}
				}
			}
			return false;
		}

		private bool inServices(string serviceName)
        {
			for (int i = 0; i < services.Length; i++)
            {
				if (services[i] == serviceName)
                {
					return true;
                }
            }
			return false;
        }

		//attempts to remove a service and if the service is removed then returns true
		//if service is not in services then it returns false
		public bool removeService(string serviceName)
		{
			if (serviceName != null && services != null)
			{
				for (int i = 0; i < services.Length; i++)
				{
					if (serviceName == services[i])
					{
						string[] temp = new string[services.Length - 1];
						for (int j = 0; j < i; j++)
                        {
							temp[j] = services[j];
                        }
						for (int j = i + 1; j < services.Length; j++)
                        {
							temp[j - 1] = services[j];
                        }
						services = temp;
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

		public string[] getServices()
		{
			return services;
		}

		public void setServies(string[] services2)
		{
			//if (services2 != null)
			//{
				services = new string[services2.Length];
				for (int i = 0; i < services2.Length; i++)
				{

					this.services[i] = services2[i];
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
