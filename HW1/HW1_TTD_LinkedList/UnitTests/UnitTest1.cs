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
    }
}
