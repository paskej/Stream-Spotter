using System;

namespace HW1_TTD_LinkedList
{
    public class LinkedList
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        internal class Node
        {
            internal int data;
            internal Node next;
            public Node(int d)
            {
                data = d;
                next = null;
            }
        }

        private Node head;
        public LinkedList()
        {
            head = null;
        }

        public int getHeadData()
		{
            return head.data;
		}

        public bool AddToHead(int newData)
		{
            bool added = false;
            Node add = new Node(newData);
            if (add != null)
            {
                if (head == null)
                {
                    head = add;
                    added = true;
                }
                else
                {
                    Node temp = head;
                    head = add;
                    head.next = temp;
                    added = true;
                }
            }
            return added;
		}

    }
}
