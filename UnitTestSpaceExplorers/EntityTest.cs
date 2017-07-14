using System;
using SpaceExplorers;
using SFML.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSpaceExplorers
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void TestRectInterpolateFixedTopLeft()
        {
            Entity testEnt = new Entity();
            IntRect result = testEnt.RectInterpolate(new IntRect(), new IntRect(0, 0, 50, 50), 5);
            Assert.AreEqual(result, new IntRect(0, 0, 10, 10));
        }

        [TestMethod]
        public void TestRectInterpolateSquareExpand()
        {
            Entity testEnt = new Entity();
            IntRect result = testEnt.RectInterpolate(new IntRect(10, 10, 10, 10), new IntRect(0, 0, 30, 30), 2);
            Assert.AreEqual(result, new IntRect(5, 5, 20, 20));
        }

        [TestMethod]
        public void TestRectInterpolateRectangleExpand()
        {
            Entity testEnt = new Entity();
            IntRect result = testEnt.RectInterpolate(new IntRect(10, 10, 10, 10), new IntRect(0, 0, 60, 30), 2);
            Assert.AreEqual(result, new IntRect(5, 5, 35, 20));
        }

        [TestMethod]
        public void TestRectInterpolateSquareShrink()
        {
            Entity testEnt = new Entity();
            IntRect result = testEnt.RectInterpolate(new IntRect(0, 0, 30, 30), new IntRect(10, 10, 10, 10), 2);
            Assert.AreEqual(result, new IntRect(5, 5, 20, 20));
        }

        [TestMethod]
        public void TestRectInterpolateRectangleShrink()
        {
            Entity testEnt = new Entity();
            IntRect result = testEnt.RectInterpolate(new IntRect(0, 0, 60, 30), new IntRect(10, 10, 10, 10), 2);
            Assert.AreEqual(result, new IntRect(5, 5, 35, 20));
        }
    }
}
