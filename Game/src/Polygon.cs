using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace SpaceExplorers {
    /// <summary>
    /// Modified version of code written by Laurent Cozic, obtained from https://www.codeproject.com/Articles/15573/D-Polygon-Collision-Detection
    /// Modified version of code written by codeproject user fgshen, obtained from https://www.codeproject.com/Articles/8238/Polygon-Triangulation-in-C
    /// </summary>
    public class Polygon {
        public enum VertexType
        {
            ErrorPoint,
            ConvexPoint,
            ConcavePoint
        }

        public enum PolygonType
        {
            Unknown,
            Convex,
            Concave
        }

        public enum PointPosition
        {
            Inside,
            Above,
            Below,
            Left,
            Right,
            None
        }

        public List<Vector> Points = new List<Vector>();
		private List<Vector> edges = new List<Vector>();

		public void BuildEdges() {
			Vector p1;
			Vector p2;
			edges.Clear();
			for (int i = 0; i < Points.Count; i++) {
				p1 = Points[i];
				if (i + 1 >= Points.Count) {
					p2 = Points[0];
				} else {
					p2 = Points[i + 1];
				}
				edges.Add(p2 - p1);
			}
		}

		public List<Vector> Edges {
			get { return edges; }
		}

		public Vector Center {
			get {
				float totalX = 0;
				float totalY = 0;
				for (int i = 0; i < Points.Count; i++) {
					totalX += Points[i].X;
					totalY += Points[i].Y;
				}

				return new Vector(totalX / Points.Count, totalY / Points.Count);
			}
		}

        public Polygon Copy()
        {
            Polygon copy = new Polygon();
            foreach (var point in Points)
            {
                copy.Points.Add(point.Copy());
            }
            copy.BuildEdges();
            return copy;
        }

		public void Offset(Vector v) {
			Offset(v.X, v.Y);
		}

		public void Offset(float x, float y) {
			for (int i = 0; i < Points.Count; i++) {
				Vector p = Points[i];
				Points[i] = new Vector(p.X + x, p.Y + y);
			}
		}

		public override string ToString() {
			string result = "";

			for (int i = 0; i < Points.Count; i++) {
				if (result != "") result += " ";
				result += "{" + Points[i].ToString(true) + "}";
			}

			return result;
		}

        // Structure that stores the results of the PolygonCollision function
        public struct PolygonCollisionResult
        {
            public bool WillIntersect; // Are the polygons going to intersect forward in time?
            public bool Intersect; // Are the polygons currently intersecting
            public Vector MinimumTranslationVector; // The translation to apply to polygon A to push the polygons apart.
        }

        // Check if polygon A is going to collide with polygon B for the given velocity
        public PolygonCollisionResult PolygonCollision(Polygon polygon, Vector velocity)
        {
            PolygonCollisionResult result = new PolygonCollisionResult();
            result.Intersect = true;
            result.WillIntersect = true;

            int edgeCountA = Edges.Count;
            int edgeCountB = polygon.Edges.Count;
            float minIntervalDistance = float.PositiveInfinity;
            Vector translationAxis = new Vector();
            Vector edge;

            // Loop through all the edges of both polygons
            for (int edgeIndex = 0; edgeIndex < edgeCountA + edgeCountB; edgeIndex++)
            {
                if (edgeIndex < edgeCountA)
                {
                    edge = Edges[edgeIndex];
                }
                else
                {
                    edge = polygon.Edges[edgeIndex - edgeCountA];
                }

                // ===== 1. Find if the polygons are currently intersecting =====

                // Find the axis perpendicular to the current edge
                Vector axis = new Vector(-edge.Y, edge.X);
                axis.Normalize();

                // Find the projection of the polygon on the current axis
                float minA = 0; float minB = 0; float maxA = 0; float maxB = 0;
                ProjectPolygon(axis, this, ref minA, ref maxA);
                ProjectPolygon(axis, polygon, ref minB, ref maxB);

                // Check if the polygon projections are currentlty intersecting
                if (IntervalDistance(minA, maxA, minB, maxB) > 0) result.Intersect = false;

                // ===== 2. Now find if the polygons *will* intersect =====

                // Project the velocity on the current axis
                float velocityProjection = axis.DotProduct(velocity);

                // Get the projection of polygon A during the movement
                if (velocityProjection < 0)
                {
                    minA += velocityProjection;
                }
                else
                {
                    maxA += velocityProjection;
                }

                // Do the same test as above for the new projection
                float intervalDistance = IntervalDistance(minA, maxA, minB, maxB);
                if (intervalDistance > 0) result.WillIntersect = false;

                // If the polygons are not intersecting and won't intersect, exit the loop
                if (!result.Intersect && !result.WillIntersect) break;

                // Check if the current interval distance is the minimum one. If so store
                // the interval distance and the current distance.
                // This will be used to calculate the minimum translation vector
                intervalDistance = Math.Abs(intervalDistance);
                if (intervalDistance < minIntervalDistance)
                {
                    minIntervalDistance = intervalDistance;
                    translationAxis = axis;

                    Vector d = Center - polygon.Center;
                    if (d.DotProduct(translationAxis) < 0) translationAxis = -translationAxis;
                }
            }

            // The minimum translation vector can be used to push the polygons appart.
            // First moves the polygons by their velocity
            // then move polygonA by MinimumTranslationVector.
            if (result.WillIntersect) result.MinimumTranslationVector = translationAxis * minIntervalDistance;

            return result;
        }

        // Calculate the distance between [minA, maxA] and [minB, maxB]
        // The distance will be negative if the intervals overlap
        public float IntervalDistance(float minA, float maxA, float minB, float maxB)
        {
            if (minA < minB)
            {
                return minB - maxA;
            }
            else
            {
                return minA - maxB;
            }
        }

        // Calculate the projection of a polygon on an axis and returns it as a [min, max] interval
        public void ProjectPolygon(Vector axis, Polygon polygon, ref float min, ref float max)
        {
            // To project a point on an axis use the dot product
            float d = axis.DotProduct(polygon.Points[0]);
            min = d;
            max = d;
            for (int i = 0; i < polygon.Points.Count; i++)
            {
                d = polygon.Points[i].DotProduct(axis);
                if (d < min)
                {
                    min = d;
                }
                else
                {
                    if (d > max)
                    {
                        max = d;
                    }
                }
            }
        }

        /// <summary>
        /// Returns Above if the point is directly above the polygon or Below if it is directly below, 
        /// Inside if it is inside the polygon or None if it is to the left or right of the polygon.
        /// </summary>
        /// <param name="point">The point to compare to the polygon</param>
        /// <returns>Above, Below, Inside, or None</returns>
        public PointPosition PointYRelation(Vector point)
        {
            PointPosition ret = PointPosition.None;
            for (int i = 0; i < Points.Count; i++)
            {
                LineSegment line = new LineSegment(Points[i], Points[Utility.ValueWrap(i + 1, Points.Count)]);
                if (line.PointWithinXBounds(point))
                { //Point is above, below, or in given line
                    int relation = line.GetPointLocation(point);
                    if (relation == -1)
                    {
                        if (ret == PointPosition.Below)
                        {
                            return PointPosition.Inside;
                        }
                        else
                        {
                            ret = PointPosition.Above;
                        }
                    }
                    else if (relation == 1)
                    {
                        if (ret == PointPosition.Above)
                        {
                            return PointPosition.Inside;
                        }
                        else
                        {
                            ret = PointPosition.Below;
                        }
                    }
                    else
                    {
                        return PointPosition.Inside;
                    }
                }
            }
            return ret;
        }

        public List<Polygon> MakeConvex()
        {
            List<Polygon> ret;

            if (GetPolygonType() == PolygonType.Convex)
            {
                ret = new List<Polygon>
                {
                    this
                };
            }
            else
            {
                ret = new List<Polygon>();
                Polygon copy = Copy();

                bool done = false;
                if (copy.Points.Count == 3) //triangle, don't have to cut ear
                {
                    done = true;
                    ret.Add(this);
                }

                int i;
                while (done == false) //UpdatedPolygon
                {
                    i = 0;
                    bool notFound = true;
                    while (notFound
                        && (i < copy.Points.Count)) //loop till find an ear
                    {
                        if (copy.IsEar(i))
                            notFound = false; //got one, pt is an ear
                        else
                            i++;
                    } //bNotFound
                      //An ear found:}
                    if (copy.Points[i] != null)
                    {
                        Polygon triangle = new Polygon();
                        triangle.Points.Add(copy.Points[i].Copy());
                        triangle.Points.Add(copy.Points[Utility.ValueWrap(i + 1, copy.Points.Count)].Copy());
                        triangle.Points.Add(copy.Points[Utility.ValueWrap(i - 1, copy.Points.Count)].Copy());
                        triangle.BuildEdges();
                        ret.Add(triangle);
                        copy.Points.RemoveAt(i);
                    }

                    if (copy.GetPolygonType() == PolygonType.Convex)
                    {
                        done = true;
                        copy.BuildEdges();
                        ret.Add(copy);
                    }
                }
            }
            return ret;
        }

        public List<Polygon> Triangulate()
        {
            List<Polygon> ret = new List<Polygon>();
            Polygon copy = Copy();

            bool done = false;
            if (copy.Points.Count == 3) //triangle, don't have to cut ear
            {
                done = true;
                ret.Add(this);
            }

            int i;
            while (done == false) //UpdatedPolygon
            {
                i = 0;
                bool notFound = true;
                while (notFound
                    && (i < copy.Points.Count)) //loop till find an ear
                {
                    if (copy.IsEar(i))
                        notFound = false; //got one, pt is an ear
                    else
                        i++;
                } //bNotFound
                  //An ear found:}
                if (copy.Points[i] != null)
                {
                    Polygon triangle = new Polygon();
                    triangle.Points.Add(copy.Points[i].Copy());
                    triangle.Points.Add(copy.Points[Utility.ValueWrap(i + 1, copy.Points.Count)].Copy());
                    triangle.Points.Add(copy.Points[Utility.ValueWrap(i - 1, copy.Points.Count)].Copy());
                    triangle.BuildEdges();
                    ret.Add(triangle);
                    copy.Points.RemoveAt(i);
                }

                if (copy.Points.Count == 3)
                {
                    done = true;
                    copy.BuildEdges();
                    ret.Add(copy);
                }
            }
            return ret;
        }

        /// <summary>
        /// Checks to see if a polygon is convex or concave, does not work on self-intersecting polygons.
        /// </summary>
        /// <returns>An enum for the type of the polygon.</returns>
        public PolygonType GetPolygonType()
        {
            int numOfVertices = Points.Count;
            bool signChanged = false;
            int count = 0;
            int j = 0, k = 0;

            for (int i = 0; i < numOfVertices; i++)
            {
                j = (i + 1) % numOfVertices; //j:=i+1;
                k = (i + 2) % numOfVertices; //k:=i+2;

                double crossProduct = (Points[j].X - Points[i].X)
                    * (Points[k].Y - Points[j].Y);
                crossProduct = crossProduct - (
                    (Points[j].Y - Points[i].Y)
                    * (Points[k].X - Points[j].X)
                    );

                //change the value of nCount
                if ((crossProduct > 0) && (count == 0))
                    count = 1;
                else if ((crossProduct < 0) && (count == 0))
                    count = -1;

                if (((count == 1) && (crossProduct < 0))
                    || ((count == -1) && (crossProduct > 0)))
                    signChanged = true;
            }

            if (signChanged)
                return PolygonType.Concave;
            else
                return PolygonType.Convex;
        }

        /****************************************************************
		To check whether the Vertex is an ear or not based updated Polygon vertices

		ref. www-cgrl.cs.mcgill.ca/~godfried/teaching/cg-projects/97/Ian
		/algorithm1.html

		If it is an ear, return true,
		If it is not an ear, return false;
		*****************************************************************/
        private bool IsEar(int index)
        {
            bool ear = true;
            if (PolygonVertexType(index) == VertexType.ConvexPoint)
            {
                List<Vector> trianglePoints = new List<Vector>();
                trianglePoints.Add(Points[index]);
                trianglePoints.Add(Points[Utility.ValueWrap(index - 1, Points.Count)]);
                trianglePoints.Add(Points[Utility.ValueWrap(index + 1, Points.Count)]);

                for (int i = 0; i < Points.Count; i++)
                {
                    Vector point = Points[i];
                    if (!(point.EqualsThreshold(trianglePoints[0]) || point.EqualsThreshold(trianglePoints[1]) || point.EqualsThreshold(trianglePoints[2])))
                    {
                        if (TriangleContainsPoint(trianglePoints, point))
                            ear = false;
                    }
                }
            } //ThePolygon.getVertexType(Vertex)=ConvexPt
            else  //concave point
                ear = false; //not an ear/
            return ear;
        }

        /***********************************************
			To check a vertex concave point or a convex point
			-----------------------------------------------------------
			The out polygon is in count clock-wise direction
		************************************************/
        public VertexType PolygonVertexType(int index)
        {
            VertexType vertexType = VertexType.ErrorPoint;

            List<Vector> trianglePoints = new List<Vector>();
            trianglePoints.Add(Points[Utility.ValueWrap(index - 1, Points.Count)]);
            trianglePoints.Add(Points[index]);
            trianglePoints.Add(Points[Utility.ValueWrap(index + 1, Points.Count)]);

            double area = PolygonArea(trianglePoints);

            if (area < 0)
                vertexType = VertexType.ConvexPoint;
            else if (area > 0)
                vertexType = VertexType.ConcavePoint;
            return vertexType;
        }

        /******************************************
        To calculate the area of polygon made by given points 

        Good for polygon with holes, but the vertices make the 
        hole  should be in different direction with bounding 
        polygon.

        Restriction: the polygon is not self intersecting
        ref: www.swin.edu.au/astronomy/pbourke/
            geometry/polyarea/

        As polygon in different direction, the result could be
        in different sign:
        If dblArea>0 : polygon in clock wise to the user 
        If dblArea<0: polygon in count clock wise to the user 		
        *******************************************/
        public static double PolygonArea(List<Vector> points)
        {
            double dblArea = 0;
            int numPts = points.Count;

            int j;
            for (int i = 0; i < numPts; i++)
            {
                j = (i + 1) % numPts;
                dblArea += points[i].X * points[j].Y;
                dblArea -= (points[i].Y * points[j].X);
            }

            dblArea = dblArea / 2;
            return dblArea;
        }

        /**********************************************************
		To check the Pt is in the Triangle or not.
		If the Pt is in the line or is a vertex, then return true.
		If the Pt is out of the Triangle, then return false.

		This method is used for triangle only.
		***********************************************************/
        private bool TriangleContainsPoint(List<Vector> trianglePoints, Vector point)
        {
            if (trianglePoints.Count != 3)
                return false;

            foreach (Vector trianglePoint in trianglePoints)
            {
                if (point.EqualsThreshold(trianglePoint))
                    return true;
            }

            bool ret = false;

            LineSegment line0 = new LineSegment(trianglePoints[0], trianglePoints[1]);
            LineSegment line1 = new LineSegment(trianglePoints[1], trianglePoints[2]);
            LineSegment line2 = new LineSegment(trianglePoints[2], trianglePoints[0]);

            if (line0.InLine(point) || line1.InLine(point)
                || line2.InLine(point))
                ret = true;
            else //point is not in the lines
            {
                List<Vector> triangle0 = new List<Vector>();
                triangle0.Add(trianglePoints[0]);
                triangle0.Add(trianglePoints[1]);
                triangle0.Add(point);
                double dblArea0 = Polygon.PolygonArea(triangle0);
                List<Vector> triangle1 = new List<Vector>();
                triangle1.Add(trianglePoints[1]);
                triangle1.Add(trianglePoints[2]);
                triangle1.Add(point);
                double dblArea1 = Polygon.PolygonArea(triangle1);
                List<Vector> triangle2 = new List<Vector>();
                triangle2.Add(trianglePoints[2]);
                triangle2.Add(trianglePoints[0]);
                triangle2.Add(point);
                double dblArea2 = Polygon.PolygonArea(triangle2);

                if (dblArea0 > 0)
                {
                    if ((dblArea1 > 0) && (dblArea2 > 0))
                        ret = true;
                }
                else if (dblArea0 < 0)
                {
                    if ((dblArea1 < 0) && (dblArea2 < 0))
                        ret = true;
                }
            }
            return ret;
        }
    }

}

