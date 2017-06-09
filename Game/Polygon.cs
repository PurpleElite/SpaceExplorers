using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace SpaceExplorers {
    /// <summary>
    /// Modified version of code written by Laurent Cozic, obtained from https://www.codeproject.com/Articles/15573/D-Polygon-Collision-Detection
    /// </summary>
    public class Polygon {

		private List<Vector> points = new List<Vector>();
		private List<Vector> edges = new List<Vector>();

		public void BuildEdges() {
			Vector p1;
			Vector p2;
			edges.Clear();
			for (int i = 0; i < points.Count; i++) {
				p1 = points[i];
				if (i + 1 >= points.Count) {
					p2 = points[0];
				} else {
					p2 = points[i + 1];
				}
				edges.Add(p2 - p1);
			}
		}

		public List<Vector> Edges {
			get { return edges; }
		}

		public List<Vector> Points {
			get { return points; }
		}

		public Vector Center {
			get {
				float totalX = 0;
				float totalY = 0;
				for (int i = 0; i < points.Count; i++) {
					totalX += points[i].X;
					totalY += points[i].Y;
				}

				return new Vector(totalX / (float)points.Count, totalY / (float)points.Count);
			}
		}

		public void Offset(Vector v) {
			Offset(v.X, v.Y);
		}

		public void Offset(float x, float y) {
			for (int i = 0; i < points.Count; i++) {
				Vector p = points[i];
				points[i] = new Vector(p.X + x, p.Y + y);
			}
		}

		public override string ToString() {
			string result = "";

			for (int i = 0; i < points.Count; i++) {
				if (result != "") result += " ";
				result += "{" + points[i].ToString(true) + "}";
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

    }

}

