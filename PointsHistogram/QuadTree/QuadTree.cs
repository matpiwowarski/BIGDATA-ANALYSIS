using System;
namespace QuadTree
{
    public class QuadTree
    {
        public Point CurrentPoint;

        // Children of this tree 
        public QuadTree topLeftTree;
        public QuadTree topRightTree;
        public QuadTree botLeftTree;
        public QuadTree botRightTree;

        // constructors
        public QuadTree(Point startingPoint)
        {
            CurrentPoint = startingPoint;
        }

        public QuadTree()
        {

        }

        // methods

        public void Insert(Point point)
        {
            if(point == null)
            {
                return;
            }

            /*
            if(InBoundary(point.Position) == false)
            {
                return;
            }
            */

            if(CurrentPoint == null)
            {
                CurrentPoint = point;
                return;
            }

            // left
            if(point.Position.X < this.CurrentPoint.Position.X)
            {
                // top
                if(point.Position.Y < this.CurrentPoint.Position.Y)
                {
                    if(topLeftTree == null)
                        topLeftTree = new QuadTree();
                    topLeftTree.Insert(point);
                }
                else // bot
                {
                    if(botLeftTree == null)
                        botLeftTree = new QuadTree();
                    botLeftTree.Insert(point);
                }
            }
            else // right
            {
                // top
                if (point.Position.Y < this.CurrentPoint.Position.Y)
                {
                    if(topRightTree == null)
                        topRightTree = new QuadTree();
                    topRightTree.Insert(point);
                }
                else // bot
                {
                    if(botRightTree == null)
                        botRightTree = new QuadTree();
                    botRightTree.Insert(point);
                }
            }
            
        } 

        /*
        public bool InBoundary(Position position)
        {
            // checking X
            if(position.X >= TopLeft.X && position.X <= BotRight.X)
            {
                // checking Y
                if(position.Y >= TopLeft.Y && position.Y <= BotRight.Y)
                {
                    // position is inside boundary
                    return true;
                }
            }

            // position is outside boundary
            return false;
        }
        */

    }
}
