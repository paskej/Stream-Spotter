using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW1_TTD_LinkedList;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1s
    {
        [TestMethod]
        public void TestCreateIsntNull()
        {
            HW1_TTD_LinkedList linkedList = null;
            linkedList = new HW1_TTD_LinkedList();
            Assert.AreNotEqual(linkedList, null, "List is null");
        }
    }
}
