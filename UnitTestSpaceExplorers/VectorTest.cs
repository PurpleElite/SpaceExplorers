using System;
using SpaceExplorers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSpaceExplorers
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void TestGetDirection45()
        {
            Vector testVector = new Vector(1, 1);
            Assert.AreEqual(testVector.GetDirection(), 45);
        }

        [TestMethod]
        public void TestGetDirection90()
        {
            Vector testVector = new Vector(0, 1);
            Assert.AreEqual(testVector.GetDirection(), 90);
        }

        [TestMethod]
        public void TestGetDirection180()
        {
            Vector testVector = new Vector(-1, 0);
            Assert.AreEqual(testVector.GetDirection(), 180);
        }

        [TestMethod]
        public void TestGetDirection225()
        {
            Vector testVector = new Vector(-1, -1);
            Assert.AreEqual(testVector.GetDirection(), 225);
        }
    }
}
