using System;
namespace QuadTree
{
    public class QuadTree
    {
        public Position TopLeft;
        public Position BotRight;

        public Point CurrentPoint;

        // Children of this tree 
        QuadTree topLeftTree;
        QuadTree topRightTree;
        QuadTree botLeftTree;
        QuadTree botRightTree;

        // constructors
        public QuadTree(Position topLeft, Position botRight)
        {
            TopLeft = topLeft;
            BotRight = botRight;
        }

        // methods

        public void Insert(Point point)
        {
            if(point == null)
            {
                return;
            }

            if(InBoundary(point.Position) == false)
            {
                return;
            }


            if(Math.Abs(TopLeft.X - BotRight.X) <= 1)
            {
                if(Math.Abs(TopLeft.Y - BotRight.Y) <= 1)
                {
                    if(CurrentPoint == null)
                    {
                        CurrentPoint = point;
                        return;
                    }
                }
            }

            // checking left
            if((TopLeft.X + BotRight.X) / 2 >= point.Position.X)
            {
                // TopLeftTree
                if((TopLeft.Y + BotRight.Y) / 2 >= point.Position.Y)
                {
                    if (topLeftTree == null)
                    {
                        topLeftTree = new QuadTree(
                            new Position(TopLeft.X, TopLeft.Y),
                            new Position((TopLeft.X + BotRight.X) / 2, (TopLeft.Y + BotRight.Y) / 2)
                            );
                    }
                    topLeftTree.Insert(point);
                }
                else // BotLeftTree
                {
                    if(botLeftTree == null)
                    {
                        botLeftTree = new QuadTree(
                            new Position(TopLeft.X, (TopLeft.Y + BotRight.Y) / 2),
                            new Position((TopLeft.X + BotRight.X) / 2, BotRight.Y)
                    );
                    }
                    botLeftTree.Insert(point);
                }
            }
            else // checking right
            {
                // TopRightTree
                if ((TopLeft.Y + BotRight.Y) / 2 >= point.Position.Y)
                {
                    if (topLeftTree == null)
                    {
                        topLeftTree = new QuadTree(
                            new Position((TopLeft.X + BotRight.X) / 2, TopLeft.Y),
                            new Position(BotRight.X, (TopLeft.Y + BotRight.Y) / 2)
                            );
                    }
                    topRightTree.Insert(point);
                }
                else // BotRightTree
                {
                    if (botLeftTree == null)
                    {
                        botLeftTree = new QuadTree(
                            new Position((TopLeft.X + BotRight.X) / 2, (TopLeft.Y + BotRight.Y) / 2),
                            new Position(BotRight.X, BotRight.Y)
                    );
                    }
                    botRightTree.Insert(point);
                }
            }
            
        } 

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

    }
}
