using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    abstract class Command
    {
        protected ProfileController profile;
        public Command(ProfileController p) { profile = p; }
        public abstract void execute();
        public abstract void unexecute();
    }

    // wrap adding a new entry to the phonebook as a command
    // hint: you should keep a record of what was added.
    class AddCommand : Command
    {
        private Profile profileAdd;
        private Result[] wishlist;
        private string[] services;
        public AddCommand(ProfileController p, Profile e) : base(p)
        {
            profileAdd = e;
        }
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
        }
        public override void unexecute()
        {
            wishlist = profile.db.getWishlist(profileAdd.id, profileAdd.id.ToString());
            string[] temp = profile.GetProfile(profileAdd.id).getServices();
            services = new string[temp.Length];
            for (int i = 0; i < temp.Length; i++)
            {
                services[i] = temp[i];
            }
            profile.RemoveProfile(profileAdd.getID());
        }

    }

    // wrap removing an entry from the phonebook as a command
    // hint: you should keep a record of what was removed.
    class RemoveCommand : Command
    {
        private Profile profileRemove;
        private Result[] wishlist;
        private string[] services;
        public RemoveCommand(ProfileController p, Profile e) : base(p)
        {
            profile = p;
            profileRemove = e;
            wishlist = profile.db.getWishlist(profileRemove.id, profileRemove.id.ToString());
        }
        public override void execute()
        {
            wishlist = profile.db.getWishlist(profileRemove.id, profileRemove.id.ToString());
            string[] temp = profile.GetProfile(profileRemove.id).getServices();
            services = new string[temp.Length];
            for(int i = 0; i < temp.Length; i++)
            {
                services[i] = temp[i];
            }
            profile.RemoveProfile(profileRemove.getID());
            
        }
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
        }
    }
}
