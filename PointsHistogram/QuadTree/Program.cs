using System;

namespace QuadTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Point point1 = new Point(3, 7, 235.98, 34);
            Point point2 = new Point(8, 1, 234.95, 37);
            Point point3 = new Point(6, 6, 246.70, 5);
            Point point4 = new Point(2, 6, 236.67, 40);
            Point point5 = new Point(1, 7, 238.30, 60);
            Point point6 = new Point(8, 6, 241.38, 36);
            Point point7 = new Point(5, 9, 1, 1);

            double startingX = 0;
            double endingX = 9;
            double startingY = 0;
            double endingY = 9;
            Position startingPosition = new Position(startingX, startingY);
            Position endingPosition = new Position(endingX, endingY);

            QuadTree center = new QuadTree(startingPosition, endingPosition);

            center.Insert(point1);
            center.Insert(point2);
            center.Insert(point3);
            center.Insert(point4);
            center.Insert(point5);
            center.Insert(point6);
            center.Insert(point7);
        }
    }
}
