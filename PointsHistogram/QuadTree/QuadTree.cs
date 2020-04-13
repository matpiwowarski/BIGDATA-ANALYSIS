using System;
namespace QuadTree
{
    public class QuadTree
    {
        public Node Root;

        public QuadTree(double startX, double startY, double endX, double endY)
        {
            Root = new Node(startX, startY, endX, endY, null);
        }

        public void Set(Point point)
        {
            if(point.X < Root.StartX || point.Y < Root.StartY || point.X > Root.EndX || point.Y > Root.EndY)
            {
                return;
            }
            else
            {
                Insert(Root, point);
            }
        }

        private void Insert(Node parent, Point point)
        {
            switch(parent.nodeType)
            {
                case NodeType.EMPTY:
                    SetPointForNode(parent, point);
                    break;
                case NodeType.LEAF:
                    if((parent.StartX + parent.EndX)/2 == point.X && (parent.StartY+parent.EndY)/2 == point.Y)
                    {
                        SetPointForNode(parent, point);
                    }
                    else
                    {
                        Split(parent);
                        Insert(parent, point);
                    }
                    break;
                case NodeType.BRANCH:
                    Insert(getQuadrant(parent, point.X, point.Y), point);
                    break;
                default:
                    break;
            }
        }

        private Node getQuadrant(Node parent, double x, double y)
        {
            double centerX = (parent.StartX + parent.EndX) / 2;
            double centerY = (parent.StartY + parent.EndY) / 2;

            if(x < centerX) // left
            {
                if(y < centerY) // top
                {
                    return parent.NW;
                }
                else // bot
                {
                    return parent.SW;
                }

            }
            else // right
            {
                if (y < centerY) // top
                {
                    return parent.NE;
                }
                else // bot
                {
                    return parent.SE;
                }
            }
        }

        private void Split(Node parent)
        {
            Point oldPoint = new Point(parent.Point.X, parent.Point.Y, parent.Point.Z, parent.Point.I);
            parent.Point = null;
            parent.nodeType = NodeType.BRANCH;

            double startX = parent.StartX;
            double startY = parent.StartY;
            double endX = parent.EndX;
            double endY = parent.EndY;

            parent.NW = new Node(startX, startY, (startX + endX) / 2, (startY + endY) / 2, parent);
            parent.NE = new Node((startX + endX) / 2, startY, endX, (startY + endY) / 2, parent);
            parent.SW = new Node(startX, (startY + endY) / 2, (startX + endX) / 2, endY, parent);
            parent.SE = new Node((startX + endX) / 2, (startY + endY) / 2, endX, endY, parent);

            Insert(parent, oldPoint);
        }

        private void SetPointForNode(Node parent, Point point)
        {
            if(parent.nodeType == NodeType.BRANCH)
            {
                return;
            }
            parent.nodeType = NodeType.LEAF;
            parent.Point = point;
        }
    }
}
