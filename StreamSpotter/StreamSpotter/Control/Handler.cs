using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    class Handler
    {
        // Invoker
        public History com_history;
        // Receiver
        public ProfileController profile { get; set; }

        public Handler()
        {
            profile = new ProfileController();
            com_history = new History();
        }
        public void AddEntry(string name, string[] services, int id)
        {
            com_history.Do(new AddCommand(profile, new Profile(name, services, id)));
        }
        public void RemoveEntry(int id)
        {
            Profile profileToRemove = profile.GetProfile(id);
            if(profileToRemove!=null)
            {
                com_history.Do(new RemoveCommand(profile, profileToRemove));
            }
        }
        public void Undo()
        {
            com_history.Undo();
        }
        public void Redo()
        {
            com_history.Redo();
        }
    }
}
