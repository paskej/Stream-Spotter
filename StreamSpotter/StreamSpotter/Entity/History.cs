using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter.Entity
{
    class History
    {
        private Stack<Command> done, undone;

        public History()
        {
            done = new Stack<Command>();
            undone = new Stack<Command>();
        }

        // execute command and store it on the done commands list;
        //   old undone commands are permanently deleted
        public void Do(Command new_cmd)
        {
            new_cmd.execute();
            undone.Clear();
            done.Push(new_cmd);
        }

        // undoes last executed command; precondition: at least one command to undo
        public void Undo()
        {
            if (done.Count != 0) 
            {
                Command temp = done.Pop();
                undone.Push(temp);
            }
        }

        // redoes last undone command; precondition: at least one command to redo
        public void Redo()
        {
            if (undone.Count != 0)
            {
                Command temp = undone.Pop();
                done.Push(temp);
            }
        }
    }
}
