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
            FloatRect result = testEnt.RectInterpolate(new FloatRect(), new FloatRect(0, 0, 50, 50), 5);
            Assert.AreEqual(new IntRect((int)result.Left, (int)result.Top, (int)result.Width, (int)result.Height), new IntRect(0, 0, 10, 10));
        }

        [TestMethod]
        public void TestRectInterpolateSquareExpand()
        {
            Entity testEnt = new Entity();
            FloatRect result = testEnt.RectInterpolate(new FloatRect(10, 10, 10, 10), new FloatRect(0, 0, 30, 30), 2);
            Assert.AreEqual(new IntRect((int)result.Left, (int)result.Top, (int)result.Width, (int)result.Height), new IntRect(5, 5, 20, 20));
        }

        [TestMethod]
        public void TestRectInterpolateRectangleExpand()
        {
            Entity testEnt = new Entity();
            FloatRect result = testEnt.RectInterpolate(new FloatRect(10, 10, 10, 10), new FloatRect(0, 0, 60, 30), 2);
            Assert.AreEqual(new IntRect((int)result.Left, (int)result.Top, (int)result.Width, (int)result.Height), new IntRect(5, 5, 35, 20));
        }

        [TestMethod]
        public void TestRectInterpolateSquareShrink()
        {
            Entity testEnt = new Entity();
            FloatRect result = testEnt.RectInterpolate(new FloatRect(0, 0, 30, 30), new FloatRect(10, 10, 10, 10), 2);
            Assert.AreEqual(new IntRect((int)result.Left, (int)result.Top, (int)result.Width, (int)result.Height), new IntRect(5, 5, 20, 20));
        }

        [TestMethod]
        public void TestRectInterpolateRectangleShrink()
        {
            Entity testEnt = new Entity();
            FloatRect result = testEnt.RectInterpolate(new FloatRect(0, 0, 60, 30), new FloatRect(10, 10, 10, 10), 2);
            Assert.AreEqual(new IntRect((int)result.Left, (int)result.Top, (int)result.Width, (int)result.Height), new IntRect(5, 5, 35, 20));
        }
    }
}
