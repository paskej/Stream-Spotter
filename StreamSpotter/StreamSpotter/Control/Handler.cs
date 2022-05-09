using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    /*******************************************************************************************************
     * Handler is only way to access undoing and redoing and also adding and removing profiles
     *******************************************************************************************************/
    class Handler
    {
        // Invoker
        public History com_history;
        // Receiver
        public ProfileController profile { get; set; }

        /*******************************************************************************************************
         * Constructor to create the profile controller to store profiles and to initialize history
         *******************************************************************************************************/
        public Handler()
        {
            profile = new ProfileController();
            com_history = new History();
        }
        /*******************************************************************************************************
         * calls history to add a new profile
         * PARAMS: string name, string[] services, int id
         *******************************************************************************************************/
        public void AddEntry(string name, string[] services, int id)
        {
            com_history.Do(new AddCommand(profile, new Profile(name, services, id)));
        }
        /*******************************************************************************************************
         * calls history to remove a profile by its id
         * PARAMS: int id
         *******************************************************************************************************/
        public void RemoveEntry(int id)
        {
            Profile profileToRemove = profile.GetProfile(id);
            if(profileToRemove!=null)
            {
                com_history.Do(new RemoveCommand(profile, profileToRemove));
            }
        }
        /*******************************************************************************************************
         * calls undo within history class to undo last do
         *******************************************************************************************************/
        public void Undo()
        {
            com_history.Undo();
        }
        /*******************************************************************************************************
         * calls redo within history class to redo last undo
         *******************************************************************************************************/
        public void Redo()
        {
            com_history.Redo();
        }
    }
}
