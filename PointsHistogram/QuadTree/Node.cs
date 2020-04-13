using System;
namespace QuadTree
{
    public class Node
    {
        public double Z { get; set; }
        public short I { get; set; }
        public Point Position { get; set; }

        public Node(Point p, double z, short i)
        {
            Z = z;
            I = i;
            Position = p;
        }
    }
}
