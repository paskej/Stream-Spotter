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


    }
}
