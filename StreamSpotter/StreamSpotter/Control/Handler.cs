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
        public MovieList movieList { get; set; }

        public Handler()
        {
            movieList = new MovieList();
            com_history = new History();
        }
        public void AddEntry(List<Result> movies)
        {
            com_history.Do(new AddCommand(new MovieList(), movies));
        }
        public void RemoveEntry(List<Result> movies)
        {
            com_history.Do(new RemoveCommand(movieList, movies));
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
