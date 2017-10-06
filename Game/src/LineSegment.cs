/**************************************************
This unit is used to collect Analytic Geometry formulars
It includes Line, Line segment and CPolygon				
																				
Development by: Frank Shen                                    
Date: 08, 2004                                                         
Modification History:													
* *** **********************************************/

using System;
namespace SpaceExplorers
{
    /// <summary>
    ///To define a line in the given coordinate system
    ///and related calculations
    ///Line Equation:ax+by+c=0
    ///</summary>

    //a Line in 2D coordinate system: ax+by+c=0
    public class CLine
    {
        //line: ax+by+c=0;
        protected double a;
        protected double b;
        protected double c;

        private void Initialize(Double angleInRad, Vector point)
        {
            //angleInRad should be between 0-Pi

            try
            {
                //if ((angleInRad<0) ||(angleInRad>Math.PI))
                if (angleInRad > 2 * Math.PI)
                {
                    Console.WriteLine("The input line angle" +
                        " {0} is wrong. It should be between 0-2*PI.", angleInRad);
                }

                if (Math.Abs(angleInRad - Math.PI / 2) <
                    0.00001) //vertical line
                {
                    a = 1;
                    b = 0;
                    c = -point.X;
                }
                else //not vertical line
                {
                    a = -Math.Tan(angleInRad);
                    b = 1;
                    c = -a * point.X - b * point.Y;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message + e.StackTrace);
            }
        }


        public CLine(Double angleInRad, Vector point)
        {
            Initialize(angleInRad, point);
        }

        public CLine(Vector point1, Vector point2)
        {
            try
            {
                if (point1.Equals(point2))
                {
                    Console.WriteLine("The input points are the same");
                }

                //Point1 and Point2 are different points:
                if (Math.Abs(point1.X - point2.X)
                    < 0.00001) //vertical line
                {
                    Initialize(Math.PI / 2, point1);
                }
                else if (Math.Abs(point1.Y - point2.Y)
                    < 0.00001) //Horizontal line
                {
                    Initialize(0, point1);
                }
                else //normal line
                {
                    double m = (point2.Y - point1.Y) / (point2.X - point1.X);
                    double alphaInRad = Math.Atan(m);
                    Initialize(alphaInRad, point1);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message + e.StackTrace);
            }
        }

        public CLine(CLine copiedLine)
        {
            this.a = copiedLine.a;
            this.b = copiedLine.b;
            this.c = copiedLine.c;
        }

        /*** calculate the distance from a given point to the line ***/
        public double GetDistance(Vector point)
        {
            double x0 = point.X;
            double y0 = point.Y;

            double d = Math.Abs(a * x0 + b * y0 + c);
            d = d / (Math.Sqrt(a * a + b * b));

            return d;
        }

        /*** point(x, y) in the line, based on y, calculate x ***/
        public double GetX(double y)
        {
            //if the line is a horizontal line (a=0), it will return a NaN:
            double x;
            try
            {
                x = -(b * y + c) / a;
            }
            catch (Exception e)  //Horizontal line a=0;
            {
                x = System.Double.NaN;
                System.Diagnostics.Trace.
                    WriteLine(e.Message + e.StackTrace);
            }

            return x;
        }

        /*** point(x, y) in the line, based on x, calculate y ***/
        public double GetY(double x)
        {
            //if the line is a vertical line, it will return a NaN:
            double y;
            try
            {
                y = -(a * x + c) / b;
            }
            catch (Exception e)
            {
                y = System.Double.NaN;
                System.Diagnostics.Trace.
                    WriteLine(e.Message + e.StackTrace);
            }
            return y;
        }

        /*** is it a vertical line:***/
        public bool VerticalLine()
        {
            if (Math.Abs(b - 0) < 0.00001)
                return true;
            else
                return false;
        }

        /*** is it a horizontal line:***/
        public bool HorizontalLine()
        {
            if (Math.Abs(a - 0) < 0.00001)
                return true;
            else
                return false;
        }

        /*** calculate line angle in radian: ***/
        public double GetLineAngle()
        {
            if (b == 0)
            {
                return Math.PI / 2;
            }
            else //b!=0
            {
                double tanA = -a / b;
                return Math.Atan(tanA);
            }
        }

        public bool Parallel(CLine line)
        {
            bool bParallel = false;
            if (this.a / this.b == line.a / line.b)
                bParallel = true;

            return bParallel;
        }

        /**************************************
		 Calculate intersection point of two lines
		 if two lines are parallel, return null
		 * ************************************/
        public Vector IntersecctionWith(CLine line)
        {
            Vector point = new Vector();
            double a1 = a;
            double b1 = b;
            double c1 = c;

            double a2 = line.a;
            double b2 = line.b;
            double c2 = line.c;

            if (!(Parallel(line))) //not parallen
            {
                point.X = (float)((c2 * b1 - c1 * b2) / (a1 * b2 - a2 * b1));
                point.Y = (float)((a1 * c2 - c1 * a2) / (a2 * b2 - a1 * b2));
            }
            return point;
        }
    }

    public class CLineSegment : CLine
    {
        //line: ax+by+c=0, with start point and end point
        //direction from start point ->end point
        private Vector startPoint;
        private Vector endPoint;

        public Vector StartPoint
        {
            get
            {
                return startPoint;
            }
        }

        public Vector EndPoint
        {
            get
            {
                return endPoint;
            }
        }

        public CLineSegment(Vector startPoint, Vector endPoint)
            : base(startPoint, endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        /*** chagne the line's direction ***/
        public void ChangeLineDirection()
        {
            Vector tempPt;
            tempPt = this.startPoint;
            this.startPoint = this.endPoint;
            this.endPoint = tempPt;
        }

        /*** To calculate the line segment length:   ***/
        public double GetLineSegmentLength()
        {
            double d = (endPoint.X - startPoint.X) * (endPoint.X - startPoint.X);
            d += (endPoint.Y - startPoint.Y) * (endPoint.Y - startPoint.Y);
            d = Math.Sqrt(d);

            return d;
        }

        /********************************************************** 
			Get point location, using windows coordinate system: 
			y-axes points down.
			Return Value:
			-1:point at the left of the line (or above the line if the line is horizontal)
			 0: point in the line segment or in the line segment 's extension
			 1: point at right of the line (or below the line if the line is horizontal)    
		 ***********************************************************/
        public int GetPointLocation(Vector point)
        {
            double Ax, Ay, Bx, By, Cx, Cy;
            Bx = endPoint.X;
            By = endPoint.Y;

            Ax = startPoint.X;
            Ay = startPoint.Y;

            Cx = point.X;
            Cy = point.Y;

            if (this.HorizontalLine())
            {
                if (Math.Abs(Ay - Cy) < 0.00001) //equal
                    return 0;
                else if (Ay > Cy)
                    return -1;   //Y Axis points down, point is above the line
                else //Ay<Cy
                    return 1;    //Y Axis points down, point is below the line
            }
            else //Not a horizontal line
            {
                //make the line direction bottom->up
                if (endPoint.Y > startPoint.Y)
                    this.ChangeLineDirection();

                double L = this.GetLineSegmentLength();
                double s = ((Ay - Cy) * (Bx - Ax) - (Ax - Cx) * (By - Ay)) / (L * L);

                //Note: the Y axis is pointing down:
                if (Math.Abs(s - 0) < 0.00001) //s=0
                    return 0; //point is in the line or line extension
                else if (s > 0)
                    return -1; //point is left of line or above the horizontal line
                else //s<0
                    return 1;
            }
        }

        /***Get the minimum x value of the points in the line***/
        public double GetXmin()
        {
            return Math.Min(startPoint.X, endPoint.X);
        }

        /***Get the maximum  x value of the points in the line***/
        public double GetXmax()
        {
            return Math.Max(startPoint.X, endPoint.X);
        }

        /***Get the minimum y value of the points in the line***/
        public double GetYmin()
        {
            return Math.Min(startPoint.Y, endPoint.Y);
        }

        /***Get the maximum y value of the points in the line***/
        public double GetYmax()
        {
            return Math.Max(startPoint.Y, endPoint.Y);
        }

        /***Check whether this line is in a longer line***/
        public bool InLine(CLineSegment longerLineSegment)
        {
            bool bInLine = false;
            if ((longerLineSegment.InLine(startPoint)) &&
                (longerLineSegment.InLine(endPoint)))
                bInLine = true;
            return bInLine;
        }

        /***To check whether a point is in a line segment***/
        public bool InLine(Vector point)
        {
            bool bInline = false;

            double Ax, Ay, Bx, By, Cx, Cy;
            Bx = EndPoint.X;
            By = EndPoint.Y;
            Ax = StartPoint.X;
            Ay = StartPoint.Y;
            Cx = point.X;
            Cy = point.Y;

            double L = GetLineSegmentLength();
            double s = Math.Abs(((Ay - Cy) * (Bx - Ax) - (Ax - Cx) * (By - Ay)) / (L * L));

            if (Math.Abs(s - 0) < 0.00001)
            {
                if ((point.Equals(StartPoint)) ||
                    (point.Equals(EndPoint)))
                    bInline = true;
                else if ((Cx < GetXmax())
                    && (Cx > GetXmin())
                    && (Cy < GetYmax())
                    && (Cy > GetYmin()))
                    bInline = true;
            }
            return bInline;
        }

        /************************************************
		 * Offset the line segment to generate a new line segment
		 * If the offset direction is along the x-axis or y-axis, 
		 * Parameter is true, other wise it is false
		 * ***********************************************/
        public CLineSegment OffsetLine(double distance, bool rightOrDown)
        {
            //offset a line with a given distance, generate a new line
            //rightOrDown=true means offset to x incress direction,
            // if the line is horizontal, offset to y incress direction

            CLineSegment line;
            Vector newStartPoint = new Vector();
            Vector newEndPoint = new Vector();

            double alphaInRad = GetLineAngle(); // 0-PI
            if (rightOrDown)
            {
                if (HorizontalLine()) //offset to y+ direction
                {
                    newStartPoint.X = startPoint.X;
                    newStartPoint.Y = startPoint.Y + (float)distance;

                    newEndPoint.X = endPoint.X;
                    newEndPoint.Y = endPoint.Y + (float)distance;
                    line = new CLineSegment(newStartPoint, newEndPoint);
                }
                else //offset to x+ direction
                {
                    if (Math.Sin(alphaInRad) > 0)
                    {
                        newStartPoint.X = startPoint.X + (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newStartPoint.Y = startPoint.Y - (float)Math.Abs(distance * Math.Cos(alphaInRad));

                        newEndPoint.X = endPoint.X + (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newEndPoint.Y = endPoint.Y - (float)Math.Abs(distance * Math.Cos(alphaInRad));

                        line = new CLineSegment(
                                       newStartPoint, newEndPoint);
                    }
                    else //sin(FalphaInRad)<0
                    {
                        newStartPoint.X = startPoint.X + (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newStartPoint.Y = startPoint.Y + (float)Math.Abs(distance * Math.Cos(alphaInRad));
                        newEndPoint.X = endPoint.X + (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newEndPoint.Y = endPoint.Y + (float)Math.Abs(distance * Math.Cos(alphaInRad));

                        line = new CLineSegment(
                            newStartPoint, newEndPoint);
                    }
                }
            }//{rightOrDown}
            else //leftOrUp
            {
                if (this.HorizontalLine()) //offset to y directin
                {
                    newStartPoint.X = startPoint.X;
                    newStartPoint.Y = startPoint.Y - (float)distance;

                    newEndPoint.X = endPoint.X;
                    newEndPoint.Y = endPoint.Y - (float)distance;
                    line = new CLineSegment(
                        newStartPoint, newEndPoint);
                }
                else //offset to x directin
                {
                    if (Math.Sin(alphaInRad) >= 0)
                    {
                        newStartPoint.X = startPoint.X - (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newStartPoint.Y = startPoint.Y + (float)Math.Abs(distance * Math.Cos(alphaInRad));
                        newEndPoint.X = endPoint.X - (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newEndPoint.Y = endPoint.Y + (float)Math.Abs(distance * Math.Cos(alphaInRad));

                        line = new CLineSegment(
                            newStartPoint, newEndPoint);
                    }
                    else //sin(FalphaInRad)<0
                    {
                        newStartPoint.X = startPoint.X - (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newStartPoint.Y = startPoint.Y - (float)Math.Abs(distance * Math.Cos(alphaInRad));
                        newEndPoint.X = endPoint.X - (float)Math.Abs(distance * Math.Sin(alphaInRad));
                        newEndPoint.Y = endPoint.Y - (float)Math.Abs(distance * Math.Cos(alphaInRad));

                        line = new CLineSegment(
                            newStartPoint, newEndPoint);
                    }
                }
            }
            return line;
        }

        /********************************************************
		To check whether 2 lines segments have an intersection
		*********************************************************/
        public bool IntersectedWith(CLineSegment line)
        {
            double x1 = this.startPoint.X;
            double y1 = this.startPoint.Y;
            double x2 = this.endPoint.X;
            double y2 = this.endPoint.Y;
            double x3 = line.startPoint.X;
            double y3 = line.startPoint.Y;
            double x4 = line.endPoint.X;
            double y4 = line.endPoint.Y;

            double de = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
            //if de<>0 then //lines are not parallel
            if (Math.Abs(de - 0) < 0.00001) //not parallel
            {
                double ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / de;
                double ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / de;

                if ((ub > 0) && (ub < 1))
                    return true;
                else
                    return false;
            }
            else    //lines are parallel
                return false;
        }

    }
}
