using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW1_TTD_LinkedList;
using System;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1s
    {
        [TestMethod]
        public void TestCreateIsntNull()
        {
            Console.WriteLine("Test");
            LinkedList linkedList = null;
            linkedList = new LinkedList();
            Assert.AreNotEqual(linkedList, null, "List is null");
        }

        [TestMethod]
        public void TestAddNodeToHead()
		{
            Console.WriteLine("Test: adding a node to the head of the linked list");
            LinkedList linkedList = new LinkedList();
            linkedList.AddToHead(10);
            Assert.AreEqual(10, linkedList.getHeadData(), "The added element is the head of the linked list");
            linkedList.AddToHead(20);
            linkedList.AddToHead(40);
            linkedList.AddToHead(10920);
            Assert.AreEqual(10920, linkedList.getHeadData(), "the newest element is the head of the linked list");
		}

        [TestMethod]
        public void TestLength()
        {
            Console.WriteLine("Test: getting length of list");
            LinkedList linkedList = new LinkedList();
            linkedList.AddToHead(10);
            int length = linkedList.Length();
            Assert.AreEqual(1, length, "Length is wrong");
        }

        [TestMethod]
        public void TestIsEmpty_TRUE()
        {
            Console.WriteLine("Test: seeing if list is empty");
            LinkedList linkedList = new LinkedList();
            Boolean empty = linkedList.isEmpty();
            Assert.AreEqual(true, empty, "False Positive.");
        }

        [TestMethod]
        public void TestIsEmpty_FALSE()
        {
            Console.WriteLine("Test: seeing if list is not empty");
            LinkedList linkedList = new LinkedList();
            linkedList.AddToHead(10);
            Boolean empty = linkedList.isEmpty();
            Assert.AreEqual(false, empty, "False Negative.");
        }
    }
}
