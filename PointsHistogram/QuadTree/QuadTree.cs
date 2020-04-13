using System;
namespace QuadTree
{
    public class QuadTree
    {
        // top left
        public double StartX;
        public double StartY;
        // bot right
        public double EndX;
        public double EndY;

        public Point CurrentPoint;

        // Children of this tree 
        public QuadTree TopLeftTree;
        public QuadTree TopRightTree;
        public QuadTree BotLeftTree;
        public QuadTree BotRightTree;

        // constructors
        public QuadTree(double startX, double startY, double endX, double endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        // methods

        public void Insert(Point point)
        {
            if (point == null)
                return;

            if (InBoundary(point.X, point.Y) == false)
                return;


            // checking if we are in final place
            if(Math.Abs(StartX - EndX) <= 1 && Math.Abs(StartY - EndY) <= 1)
            {
                if(CurrentPoint == null)
                {
                    CurrentPoint = point;
                }
                return;
            }

            // left
            if ( (StartX + EndX) / 2 >= point.X)
            {
                //left top
                if((StartY + EndY) / 2 >= point.Y)
                {
                    if(TopLeftTree == null)
                    {
                        TopLeftTree = new QuadTree(StartX, StartY, (StartX+EndX)/2, (StartY+EndY)/2);
                    }
                    TopLeftTree.Insert(point);
                }
                else //left bot
                {
                    if (BotLeftTree == null)
                    {
                        BotLeftTree = new QuadTree(StartX, (StartY+EndY)/2, (StartX + EndX)/2, EndY);
                    }
                    BotLeftTree.Insert(point);
                }
            }
            else // right
            {
                //right top
                if ((StartY + EndY) / 2 >= point.Y)
                {
                    if (TopRightTree == null)
                    {
                        TopRightTree = new QuadTree((StartX + EndX) / 2, StartY, EndX, (StartY + EndY) / 2);
                    }
                    TopRightTree.Insert(point);
                }
                else //right bot
                {
                    if (BotRightTree == null)
                    {
                        BotRightTree = new QuadTree((StartX + EndX) / 2, (StartY + EndY) / 2, EndX, EndY);
                    }
                    BotRightTree.Insert(point);
                }
            }
        }
        
        public bool InBoundary(double x, double y)
        {
            // checking X
            if(x >= StartX && x <= EndX)
            {
                // checking Y
                if(y >= StartY && y <= EndY)
                {
                    // position is inside boundary
                    return true;
                }
            }

            // position is outside boundary
            return false;
        }
       
    }
}
