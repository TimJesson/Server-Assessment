using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server_Assessment;


namespace UnitTestServer
{
    [TestClass]
    public class UnitTest1
    { Database myDatabase = new Database();
        [TestMethod]

        public void TestConnectionToDataBase()
        {
            Assert.IsTrue(myDatabase.TestConenctionString());
        }

        [TestMethod]
        
          public void TestDGVCustomers()
        {
           Assert.IsTrue(myDatabase.TestFillDGVCustomerWithCustomer());
        }

        [TestMethod]
        public void TestDGVMovies()
        {
            Assert.IsTrue(myDatabase.TestFillDGVMoviesWithMovies());
        }

        [TestMethod]
        public void TestDGVRentals()
        {
            Assert.IsTrue(myDatabase.TestFillDGVRentalsWithRentals());
        }

        [TestMethod]
        public void TestDGVBiggestRenter()
        {
            Assert.IsTrue(myDatabase.TestFillDGVBRWithBR());
        }

        [TestMethod]
        public void TestDGVMPopularMovie()
        {
            Assert.IsTrue(myDatabase.TestFillDGVPMWithPM());
        }
    }
}
