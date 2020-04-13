using System;
namespace QuadTree
{
    public class QuadTree
    {
        public Position TopLeft;
        public Position BotRight;

        public Point CurrentNode;

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
    }
}
