using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void TestMethod1()
        {
            Database myDatabase = new Database();
            Assert.IsTrue(myDatabase.TestFillDGVCustomerWithCustomer());
        }
    }

}
