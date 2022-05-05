using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamSpotter
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
            if (new_cmd.GetType() == typeof(RemoveCommand))
            {
                Stack<Command> temp = new Stack<Command>();
                while (done.Count > 0)
                {
                    Command command = done.Pop();
                    command.update();
                    temp.Push(command);
                }
                while(temp.Count > 0)
                {
                    done.Push(temp.Pop());
                }
                while(undone.Count > 0)
                {
                    Command command = undone.Pop();
                    command.update();
                    temp.Push(command);
                }
                while(temp.Count > 0)
                {
                    undone.Push(temp.Pop());
                }
            }
            undone.Clear();
            done.Push(new_cmd);
        }

        // undoes last executed command; precondition: at least one command to undo
        public void Undo()
        {
            if (done.Count != 0) 
            {
                Command temp = done.Pop();
                temp.unexecute();
                if (temp.GetType() == typeof(AddCommand))
                {
                    Stack<Command> temp2 = new Stack<Command>();
                    while (undone.Count > 0)
                    {
                        Command command = undone.Pop();
                        command.update();
                        temp2.Push(command);
                    }
                    while (temp2.Count > 0)
                    {
                        undone.Push(temp2.Pop());
                    }
                    while(done.Count > 0)
                    {
                        Command command = done.Pop();
                        command.update();
                        temp2.Push(command);
                    }
                    while(temp2.Count > 0)
                    {
                        done.Push(temp2.Pop());
                    }
                }
                undone.Push(temp);
            }
        }

        // redoes last undone command; precondition: at least one command to redo
        public void Redo()
        {
            if (undone.Count != 0)
            {
                Command temp = undone.Pop();
                temp.execute();
                if (temp.GetType() == typeof(RemoveCommand))
                {
                    Stack<Command> temp2 = new Stack<Command>();
                    while (undone.Count > 0)
                    {
                        Command command = undone.Pop();
                        command.update();
                        temp2.Push(command);
                    }
                    while (temp2.Count > 0)
                    {
                        undone.Push(temp2.Pop());
                    }
                    while (done.Count > 0)
                    {
                        Command command = done.Pop();
                        command.update();
                        temp2.Push(command);
                    }
                    while (temp2.Count > 0)
                    {
                        done.Push(temp2.Pop());
                    }
                }
                done.Push(temp);
            }
        }
    }
}
