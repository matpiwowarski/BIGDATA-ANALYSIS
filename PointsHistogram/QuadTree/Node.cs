using System;
namespace QuadTree
{
    public class Node
    {
        // area
        public double StartX;
        public double StartY;
        public double EndX;
        public double EndY;

        public Node Parent;
        public Point Point;
        public NodeType nodeType = NodeType.EMPTY;

        // children
        public Node NW;
        public Node NE;
        public Node SW;
        public Node SE;

        public Node(double startX, double startY, double endX, double endY, Node parent)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
            Parent = parent;
        }
    }
}
