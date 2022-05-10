//---------------------------------------------------------------
// Name:    404 Brain Not Found
// Project: Stream Spotter
// Purpose: Allows users with streaming services to find movies and shows
// they want to watch without knowing what service it may be on
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    /*******************************************************************************************************
     * Command is an abstract class for classes that use executing and unexecuting and the profile controller
     *******************************************************************************************************/
    abstract class Command
    {
        protected ProfileController profile;
        /*******************************************************************************************************
         * Constructor the set the profile controller
         * PARAMS: ProfileController p
         *******************************************************************************************************/
        public Command(ProfileController p) { profile = p; }
        /*******************************************************************************************************
         * Abstract method to execute the command
         *******************************************************************************************************/
        public abstract void execute();
        /*******************************************************************************************************
         * Abstract method to unexecute the command
         *******************************************************************************************************/
        public abstract void unexecute();
        /*******************************************************************************************************
         * Abstract method to update the profiles in the profile controller
         *******************************************************************************************************/
        public abstract void update();
    }

    /*******************************************************************************************************
     * AddCommand implements the Command class to add a profile
     *******************************************************************************************************/
    class AddCommand : Command
    {
        private Profile profileAdd;
        private Result[] wishlist;
        private Result[] recommended;
        private string[] services;
        private bool done;
        /*******************************************************************************************************
         * Constructor the set the profile controller and store the profile to add
         * PARAMS: ProfileController p, Profile e
         *******************************************************************************************************/
        public AddCommand(ProfileController p, Profile e) : base(p)
        {
            profileAdd = e;
            done = false;
        }
        /*******************************************************************************************************
         * Method to execute adding the profile to the list of profiles
         *******************************************************************************************************/
        public override void execute()
        {
            profile.CreateProfile(profileAdd.profileName, profileAdd.getServices());
            profileAdd.id = profile.db.getProfileList().list.Length - 1;
            if (wishlist != null)
            {
                foreach (Result r in wishlist)
                {
                    profile.db.addToWishlist(profileAdd.id, profileAdd.id.ToString(), r);
                }
            }
            if(recommended != null)
            {
                profile.db.importRecommendations(profileAdd.id, recommended);
            }
            done = true;
        }
        /*******************************************************************************************************
         * Method to unexecute adding the profile to the list of profiles
         *******************************************************************************************************/
        public override void unexecute()
        {
            wishlist = profile.db.getWishlist(profileAdd.id, profileAdd.id.ToString());
            string[] temp = profile.GetProfile(profileAdd.id).getServices();
            services = new string[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                services[i] = temp[i];
            }
            if(profile.db.getRecommendations(profileAdd.id) != null)
            {
                recommended = profile.db.getRecommendations(profileAdd.id);
            }
            profile.RemoveProfile(profileAdd.getID());
            done = false;
        }
        /*******************************************************************************************************
         * Method to update the profiles in the profile controller
         *******************************************************************************************************/
        public override void update()
        {
            if (done)
            {
                ProfileList pl = profile.db.getProfileList();
                int i = 0;
                while (i < pl.list.Length)
                {
                    if(profileAdd.getProfileName() == pl.list[i].getProfileName())
                    {
                        profileAdd.id = pl.list[i].id;
                    }
                    i++;
                }
            }
        }

    }

    /*******************************************************************************************************
     * RemoveCommand implements the Command class to remove a profile
     *******************************************************************************************************/
    class RemoveCommand : Command
    {
        public Profile profileRemove;
        private Result[] wishlist;
        private Result[] recommended;
        private string[] services;
        private bool done;
        /*******************************************************************************************************
         * Constructor the set the profile controller and store the profile to remove
         * PARAMS: ProfileController p, Profile e
         *******************************************************************************************************/
        public RemoveCommand(ProfileController p, Profile e) : base(p)
        {
            profile = p;
            profileRemove = e;
            wishlist = profile.db.getWishlist(profileRemove.id, profileRemove.id.ToString());
            done = false;
        }
        /*******************************************************************************************************
         * Method to execute removing the profile to the list of profiles
         *******************************************************************************************************/
        public override void execute()
        {
            wishlist = profile.db.getWishlist(profileRemove.id, profileRemove.id.ToString());
            string[] temp = profile.GetProfile(profileRemove.id).getServices();
            services = new string[temp.Length];
            for(int i = 0; i < temp.Length; i++)
            {
                services[i] = temp[i];
            }
            if (profile.db.getRecommendations(profileRemove.id) != null)
            {
                recommended = profile.db.getRecommendations(profileRemove.id);
            }
            profile.RemoveProfile(profileRemove.getID());
            done = true;
            
        }
        /*******************************************************************************************************
         * Method to unexecute removing the profile to the list of profiles
         *******************************************************************************************************/
        public override void unexecute()
        {
            profile.CreateProfile(profileRemove.profileName, profileRemove.getServices());
            profileRemove.id = profile.db.getProfileList().list.Length - 1;
            if (wishlist != null)
            {
                foreach (Result r in wishlist)
                {
                    profile.db.addToWishlist(profileRemove.id, profileRemove.id.ToString(), r);
                }
            }
            if (recommended != null)
            {
                profile.db.importRecommendations(profileRemove.id, recommended);
            }
            done = false;
        }
        /*******************************************************************************************************
         * Method to update the profiles in the profile controller
         *******************************************************************************************************/
        public override void update()
        {
            if (!done)
            {
                ProfileList pl = profile.db.getProfileList();
                int i = 0;
                while (i < pl.list.Length)
                {
                    if (profileRemove.getProfileName() == pl.list[i].getProfileName())
                    {
                        profileRemove.id = pl.list[i].id;
                    }
                    i++;
                }
            }
        }
    }
}
