using System;
namespace QuadTree
{
    public class Node
    {
        public Point Position { get; set; }
        public double Z { get; set; }
        public short I { get; set; }


        public Node(double x, double y, double z, short i)
        {
            Point position = new Point(x, y);
            Position = position;
            Z = z;
            I = i;
        }

        public Node(Point p, double z, short i)
        {
            Z = z;
            I = i;
            Position = p;
        }
    }
}
