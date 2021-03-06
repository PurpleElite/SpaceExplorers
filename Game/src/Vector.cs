using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SpaceExplorers
{
    /// <summary>
    /// Modification of code written by Laurent Cozic, obtained from https://www.codeproject.com/Articles/15573/D-Polygon-Collision-Detection
    /// </summary>
    public struct Vector {

		public float X;
		public float Y;

        static public Vector FromPoint(int x, int y) {
			return new Vector(x, y);
		}

		public Vector(float x, float y) {
			X = x;
			Y = y;
		}

		public float Magnitude {
			get { return (float)Math.Sqrt(X * X + Y * Y); }
		}

		public void Normalize() {
			float magnitude = Magnitude;
            if (magnitude != 0)
            {
                X = X / magnitude;
                Y = Y / magnitude;
            }
		}

        public double GetDirection()
        {
            double direction = Math.Atan2(Y, X) * 180 / Math.PI;
            if (direction < 0)
            {
                direction += 360;
            }
            return direction;
        }

		public Vector GetNormalized() {
			float magnitude = Magnitude;

			return new Vector(X / magnitude, Y / magnitude);
		}

		public float DotProduct(Vector vector) {
			return X * vector.X + Y * vector.Y;
		}

		public float DistanceTo(Vector vector) {
			return (float)Math.Sqrt(Math.Pow(vector.X - X, 2) + Math.Pow(vector.Y - Y, 2));
		}

		public static Vector operator +(Vector a, Vector b) {
			return new Vector(a.X + b.X, a.Y + b.Y);
		}

		public static Vector operator -(Vector a) {
			return new Vector(-a.X, -a.Y);
		}

		public static Vector operator -(Vector a, Vector b) {
			return new Vector(a.X - b.X, a.Y - b.Y);
		}

		public static Vector operator *(Vector a, float b) {
			return new Vector(a.X * b, a.Y * b);
		}

		public static Vector operator *(Vector a, int b) {
			return new Vector(a.X * b, a.Y * b);
		}

		public static Vector operator *(Vector a, double b) {
			return new Vector((float)(a.X * b), (float)(a.Y * b));
		}

        public static Vector operator /(Vector a, float b)
        {
            return new Vector(a.X / b, a.Y / b);
        }

        public static Vector operator /(Vector a, int b)
        {
            return new Vector(a.X / b, a.Y / b);
        }

        public static Vector operator /(Vector a, double b)
        {
            return new Vector((float)(a.X / b), (float)(a.Y / b));
        }

        public override bool Equals(object obj) {
			Vector v = (Vector)obj;

			return X == v.X && Y == v.Y;
		}

		public bool Equals(Vector v) {
			return X == v.X && Y == v.Y;
		}

		public override int GetHashCode() {
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public static bool operator ==(Vector a, Vector b) {
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(Vector a, Vector b) {
			return a.X != b.X || a.Y != b.Y;
		}

		public override string ToString() {
			return X + ", " + Y;
		}

		public string ToString(bool rounded) {
			if (rounded) {
				return (int)Math.Round(X) + ", " + (int)Math.Round(Y);
			} else {
				return ToString();
			}
		}

        public bool EqualsThreshold(Vector newPoint)
        {

            double dDeff_X =
                Math.Abs(X - newPoint.X);
            double dDeff_Y =
                Math.Abs(Y - newPoint.Y);

            if ((dDeff_X < 0.00001)
                && (dDeff_Y < 0.00001))
                return true;
            else
                return false;

        }

        public Vector Copy()
        {
            return (Vector)MemberwiseClone();
        }
    }
}
