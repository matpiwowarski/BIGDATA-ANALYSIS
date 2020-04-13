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

        public void TryToInsert(Point point)
        {
            if (point.X > Root.StartX && point.Y > Root.StartY && point.X < Root.EndX && point.Y < Root.EndY)
            {
                Insert(Root, point);
            }
        }

        private void Insert(Node node, Point point)
        {
            switch(node.nodeType)
            {
                case NodeType.EMPTY:
                    // rewrite point
                    node.nodeType = NodeType.LEAF;
                    node.Point = point;
                    break;
                case NodeType.LEAF:
                    MakeBranch(node); // transform LEAF => BRANCH
                    Insert(node, point); // add new LEAF into BRANCH
                    break;
                case NodeType.BRANCH: // recursion 
                    Insert(PartOfNode(node, point.X, point.Y), point);
                    break;
                default:
                    break;
            }
        }

        private Node PartOfNode(Node node, double x, double y)
        {
            double centerX = (node.StartX + node.EndX) / 2;
            double centerY = (node.StartY + node.EndY) / 2;

            if(x < centerX) // left
            {
                if(y < centerY) // top
                {
                    return node.NW;
                }
                else // bot
                {
                    return node.SW;
                }

            }
            else // right
            {
                if (y < centerY) // top
                {
                    return node.NE;
                }
                else // bot
                {
                    return node.SE;
                }
            }
        }

        private void MakeBranch(Node node)
        {
            Point rememberPoint = new Point(node.Point.X, node.Point.Y, node.Point.Z, node.Point.I);
            node.Point = null;
            node.nodeType = NodeType.BRANCH;

            double startX = node.StartX;
            double startY = node.StartY;
            double endX = node.EndX;
            double endY = node.EndY;

            node.NW = new Node(startX, startY, (startX + endX) / 2, (startY + endY) / 2, node);
            node.NE = new Node((startX + endX) / 2, startY, endX, (startY + endY) / 2, node);
            node.SW = new Node(startX, (startY + endY) / 2, (startX + endX) / 2, endY, node);
            node.SE = new Node((startX + endX) / 2, (startY + endY) / 2, endX, endY, node);

            Insert(node, rememberPoint);
        }
    }
}
