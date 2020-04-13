using System;
namespace QuadTree
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public short I { get; set; }

        public Point(double x, double y, double z, short i)
        {
            X = x;
            Y = y;
            Z = z;
            I = i;
        }
    }
}
