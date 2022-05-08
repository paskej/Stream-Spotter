using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
	/*******************************************************************************************************
     * Used to store different profiles in the database, and 'remember' settings between program uses
     *******************************************************************************************************/
	public class ProfileList
	{
		public Profile[] list { get; set; }
	}
	public class Profile
	{
		private readonly string[] POSSIBLE_SERVICES = { "netflix", "disney", "hulu" , "prime" };
		public string[] services { get; set; }
		public string profileName { get; set; }
		public int id { get; set; }
		public bool selected { get; set; }

		//default constructor
		public Profile()
		{
			profileName = null;
			services = new string[0];
			id = -1;
			selected = false;
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
			selected = false;
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
			selected = false;
		}

		//parameterized constructor
		public Profile(string profileName, string[] services, int id)
		{
			this.profileName = profileName;
			this.id = id;
			this.services = new string[services.Length];
			for(int i = 0; i < services.Length; i++)
			{
				this.services[i] = services[i];
			}
			selected = false;
		}

		/*******************************************************************************************************
         * Adds the service to the profile's list of services based on if it is POSSIBLE_SERVICES
		 * PARAMS: string serviceName, name of the service to be added
		 * RETURN: Boolean representing if the service was able to be added
         *******************************************************************************************************/
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
		/*******************************************************************************************************
         * Determine whether a service in in the profile's list
		 * PARAMS: string serviceName, service to be checked for
		 * RETURN: boolean representing whether the service is in the list
         *******************************************************************************************************/
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
		/*******************************************************************************************************
         * sets the Profile's list of services to the new list of services
		 * PARAMS: string[] services2, list of services to be changed to
         *******************************************************************************************************/
		public void setServies(string[] services2)
		{
			services = new string[services2.Length];
			for (int i = 0; i < services2.Length; i++)
			{

				this.services[i] = services2[i];
			}
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
