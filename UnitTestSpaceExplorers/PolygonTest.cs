﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceExplorers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSpaceExplorers
{
    [TestClass]
    public class PolygonTest
    {
        [TestMethod]
        public void TestTriangulateSquare()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 0));
            testPoly.Points.Add(new Vector(0, 1));
            testPoly.Points.Add(new Vector(1, 1));
            testPoly.Points.Add(new Vector(1, 0));
            testPoly.BuildEdges();
            List<Polygon> triangles = testPoly.Triangulate();
            Assert.AreEqual(triangles.Count, 2);
        }

        [TestMethod]
        public void TestTriangulateConcave()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 0));
            testPoly.Points.Add(new Vector(1, 2));
            testPoly.Points.Add(new Vector(2, 0));
            testPoly.Points.Add(new Vector(1, 1));
            testPoly.BuildEdges();
            List<Polygon> triangles = testPoly.Triangulate();
            Assert.AreEqual(triangles.Count, 2);
        }

        [TestMethod]
        public void TestTriangulateComplex()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 301));
            testPoly.Points.Add(new Vector(70, 310));
            testPoly.Points.Add(new Vector(181, 313));
            testPoly.Points.Add(new Vector(207, 313));
            testPoly.Points.Add(new Vector(267, 310));
            testPoly.Points.Add(new Vector(271, 194));
            testPoly.Points.Add(new Vector(4, 187));
            testPoly.BuildEdges();
            List<Polygon> triangles = testPoly.Triangulate();
            Assert.AreEqual(triangles.Count, 5);
        }

        [TestMethod]
        public void TestYRelationBelow()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 0));
            testPoly.Points.Add(new Vector(0, 2));
            testPoly.Points.Add(new Vector(2, 2));
            testPoly.Points.Add(new Vector(2, 0));
            testPoly.BuildEdges();
            Vector point = new Vector(1, 3);
            Assert.AreEqual(testPoly.PointYRelation(point), Polygon.PointPosition.Below);
        }

        [TestMethod]
        public void TestYRelationAbove()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 0));
            testPoly.Points.Add(new Vector(0, 2));
            testPoly.Points.Add(new Vector(2, 2));
            testPoly.Points.Add(new Vector(2, 0));
            testPoly.BuildEdges();
            Vector point = new Vector(1, -1);
            Assert.AreEqual(testPoly.PointYRelation(point), Polygon.PointPosition.Above);
        }

        [TestMethod]
        public void TestYRelationInside()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 0));
            testPoly.Points.Add(new Vector(0, 2));
            testPoly.Points.Add(new Vector(2, 2));
            testPoly.Points.Add(new Vector(2, 0));
            testPoly.BuildEdges();
            Vector point = new Vector(1, 1);
            Assert.AreEqual(testPoly.PointYRelation(point), Polygon.PointPosition.Inside);
        }

        [TestMethod]
        public void TestYRelationNone()
        {
            Polygon testPoly = new Polygon();
            testPoly.Points.Add(new Vector(0, 0));
            testPoly.Points.Add(new Vector(0, 2));
            testPoly.Points.Add(new Vector(2, 2));
            testPoly.Points.Add(new Vector(2, 0));
            testPoly.BuildEdges();
            Vector point = new Vector(3, 3);
            Assert.AreEqual(testPoly.PointYRelation(point), Polygon.PointPosition.None);
        }
    }
}
