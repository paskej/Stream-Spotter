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
        public AddCommand(ProfileController p, Profile e) : base(p)
        {
            profileAdd = e;
        }
        public override void execute()
        {
            profile.CreateProfile(profileAdd.profileName, profileAdd.getServices());
            profileAdd.id = profile.db.getProfileList().list.Length - 1;
        }
        public override void unexecute()
        {
            profile.RemoveProfile(profileAdd.getID());
        }

    }

    // wrap removing an entry from the phonebook as a command
    // hint: you should keep a record of what was removed.
    class RemoveCommand : Command
    {
        private Profile profileRemove;
        public RemoveCommand(ProfileController p, Profile e) : base(p)
        {
            profile = p;
            profileRemove = e;
        }
        public override void execute()
        {
            profile.RemoveProfile(profileRemove.getID());
        }
        public override void unexecute()
        {
            profile.CreateProfile(profileRemove.profileName, profileRemove.getServices());
            profileRemove.id = profile.db.getProfileList().list.Length - 1;
        }
    }
}
