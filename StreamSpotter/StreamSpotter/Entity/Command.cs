using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
{
    abstract class Command
    {
        protected MovieList movieList;
        public Command(MovieList ml) { movieList = ml; }
        public abstract void execute();
        public abstract void unexecute();
    }

    // wrap adding a new entry to the phonebook as a command
    // hint: you should keep a record of what was added.
    class AddCommand : Command
    {
        private List<Result> movieList;
        public AddCommand(MovieList pb, List<Result> e) : base(pb)
        {
            movieList = e;
        }
        public override void execute()
        {
            // To do: receiver.action()
        }
        public override void unexecute()
        {
            // To do: receiver.action() 
        }

    }

    // wrap removing an entry from the phonebook as a command
    // hint: you should keep a record of what was removed.
    class RemoveCommand : Command
    {
        private List<Result> movieList;
        public RemoveCommand(MovieList pb, List<Result> e) : base(pb)
        {
            movieList = e;
        }
        public override void execute()
        {
            // To do: receiver.action()
        }
        public override void unexecute()
        {
            // To do: receiver.action() 
        }
    }
}
