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
        public abstract void update();
    }

    // wrap adding a new entry to the phonebook as a command
    // hint: you should keep a record of what was added.
    class AddCommand : Command
    {
        private Profile profileAdd;
        private Result[] wishlist;
        private string[] services;
        private bool done;
        public AddCommand(ProfileController p, Profile e) : base(p)
        {
            profileAdd = e;
            done = false;
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
            done = true;
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
            done = false;
        }

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

    // wrap removing an entry from the phonebook as a command
    // hint: you should keep a record of what was removed.
    class RemoveCommand : Command
    {
        public Profile profileRemove;
        private Result[] wishlist;
        private string[] services;
        private bool done;
        public RemoveCommand(ProfileController p, Profile e) : base(p)
        {
            profile = p;
            profileRemove = e;
            wishlist = profile.db.getWishlist(profileRemove.id, profileRemove.id.ToString());
            done = false;
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
            done = true;
            
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
            done = false;
        }
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
