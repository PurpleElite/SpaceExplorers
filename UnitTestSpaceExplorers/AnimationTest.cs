using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceExplorers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSpaceExplorers
{
    [TestClass]
    public class AnimationTest
    {
        [TestMethod]
        public void CopyTest()
        {
            Animation testAnim = new Animation("test", AnimType.Idle);
            Animation.AnimationSegment testSeg = new Animation.AnimationSegment(true);
            testSeg.Frames.Add(new Animation.Frame("", 1));
            testSeg.Frames.Add(new Animation.Frame("", 1));
            testAnim.Segments.Add(testSeg);
            Animation copyAnim = testAnim.Copy();
            copyAnim.Step();
            copyAnim.Step();
            //for some reason testSeg is not the same as the segment in testAnim?? how did that happen?
            Assert.AreEqual(testSeg.CurrentIndex, 0);
        }
    }
}
