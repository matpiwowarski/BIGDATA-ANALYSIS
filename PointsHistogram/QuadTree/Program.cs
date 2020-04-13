using System;
using System.IO;

namespace QuadTree
{
    class MainClass
    {
        public static int Main(string[] args)
        {
            /*if (args.Length < 2)
            {
                System.Console.WriteLine("Plese run program:\n program <input_file.txt> <preprocessed_file>");
                return 1;
            }
            else
            {*/
            QuadTree quadTree = new QuadTree(0, 0, 9, 9);
            quadTree.TryToInsert(new Point(0, 0, 0, 0));
            quadTree.TryToInsert(new Point(0, 1, 0, 0));
            quadTree.TryToInsert(new Point(0, 2, 0, 0));
            quadTree.TryToInsert(new Point(0, 3, 0, 0));
            quadTree.TryToInsert(new Point(0, 4, 0, 0));
            quadTree.TryToInsert(new Point(0, 5, 0, 0));
            quadTree.TryToInsert(new Point(0, 6, 0, 0));
            quadTree.TryToInsert(new Point(0, 7, 0, 0));
            quadTree.TryToInsert(new Point(0, 8, 0, 0));
            quadTree.TryToInsert(new Point(0, 9, 0, 0));

            quadTree.TryToInsert(new Point(1, 0, 0, 0));
            quadTree.TryToInsert(new Point(1, 1, 0, 0));
            quadTree.TryToInsert(new Point(1, 2, 0, 0));
            quadTree.TryToInsert(new Point(1, 3, 0, 0));
            quadTree.TryToInsert(new Point(1, 4, 0, 0));
            quadTree.TryToInsert(new Point(1, 5, 0, 0));
            quadTree.TryToInsert(new Point(1, 6, 0, 0));
            quadTree.TryToInsert(new Point(1, 7, 0, 0));
            quadTree.TryToInsert(new Point(1, 8, 0, 0));
            quadTree.TryToInsert(new Point(1, 9, 0, 0));

            quadTree.TryToInsert(new Point(2, 0, 0, 0));
            quadTree.TryToInsert(new Point(2, 1, 0, 0));
            quadTree.TryToInsert(new Point(2, 2, 0, 0));
            quadTree.TryToInsert(new Point(2, 3, 0, 0));
            quadTree.TryToInsert(new Point(2, 4, 0, 0));
            quadTree.TryToInsert(new Point(2, 5, 0, 0));
            quadTree.TryToInsert(new Point(2, 6, 0, 0));
            quadTree.TryToInsert(new Point(2, 7, 0, 0));
            quadTree.TryToInsert(new Point(2, 8, 0, 0));
            quadTree.TryToInsert(new Point(2, 9, 0, 0));

            quadTree.TryToInsert(new Point(3, 0, 0, 0));
            quadTree.TryToInsert(new Point(3, 1, 0, 0));
            quadTree.TryToInsert(new Point(3, 2, 0, 0));
            quadTree.TryToInsert(new Point(3, 3, 0, 0));
            quadTree.TryToInsert(new Point(3, 4, 0, 0));
            quadTree.TryToInsert(new Point(3, 5, 0, 0));
            quadTree.TryToInsert(new Point(3, 6, 0, 0));
            quadTree.TryToInsert(new Point(3, 7, 0, 0));
            quadTree.TryToInsert(new Point(3, 8, 0, 0));
            quadTree.TryToInsert(new Point(3, 9, 0, 0));

            quadTree.TryToInsert(new Point(4, 0, 0, 0));
            quadTree.TryToInsert(new Point(4, 1, 0, 0));
            quadTree.TryToInsert(new Point(4, 2, 0, 0));
            quadTree.TryToInsert(new Point(4, 3, 0, 0));
            quadTree.TryToInsert(new Point(4, 4, 0, 0));
            quadTree.TryToInsert(new Point(4, 5, 0, 0));
            quadTree.TryToInsert(new Point(4, 6, 0, 0));
            quadTree.TryToInsert(new Point(4, 7, 0, 0));
            quadTree.TryToInsert(new Point(4, 8, 0, 0));
            quadTree.TryToInsert(new Point(4, 9, 0, 0));

            quadTree.TryToInsert(new Point(5, 0, 0, 0));
            quadTree.TryToInsert(new Point(5, 1, 0, 0));
            quadTree.TryToInsert(new Point(5, 2, 0, 0));
            quadTree.TryToInsert(new Point(5, 3, 0, 0));
            quadTree.TryToInsert(new Point(5, 4, 0, 0));
            quadTree.TryToInsert(new Point(5, 5, 0, 0));
            quadTree.TryToInsert(new Point(5, 6, 0, 0));
            quadTree.TryToInsert(new Point(5, 7, 0, 0));
            quadTree.TryToInsert(new Point(5, 8, 0, 0));
            quadTree.TryToInsert(new Point(5, 9, 0, 0));

            quadTree.TryToInsert(new Point(6, 0, 0, 0));
            quadTree.TryToInsert(new Point(6, 1, 0, 0));
            quadTree.TryToInsert(new Point(6, 2, 0, 0));
            quadTree.TryToInsert(new Point(6, 3, 0, 0));
            quadTree.TryToInsert(new Point(6, 4, 0, 0));
            quadTree.TryToInsert(new Point(6, 5, 0, 0));
            quadTree.TryToInsert(new Point(6, 6, 0, 0));
            quadTree.TryToInsert(new Point(6, 7, 0, 0));
            quadTree.TryToInsert(new Point(6, 8, 0, 0));
            quadTree.TryToInsert(new Point(6, 9, 0, 0));

            quadTree.TryToInsert(new Point(7, 0, 0, 0));
            quadTree.TryToInsert(new Point(7, 1, 0, 0));
            quadTree.TryToInsert(new Point(7, 2, 0, 0));
            quadTree.TryToInsert(new Point(7, 3, 0, 0));
            quadTree.TryToInsert(new Point(7, 4, 0, 0));
            quadTree.TryToInsert(new Point(7, 5, 0, 0));
            quadTree.TryToInsert(new Point(7, 6, 0, 0));
            quadTree.TryToInsert(new Point(7, 7, 0, 0));
            quadTree.TryToInsert(new Point(7, 8, 0, 0));
            quadTree.TryToInsert(new Point(7, 9, 0, 0));

            quadTree.TryToInsert(new Point(8, 0, 0, 0));
            quadTree.TryToInsert(new Point(8, 1, 0, 0));
            quadTree.TryToInsert(new Point(8, 2, 0, 0));
            quadTree.TryToInsert(new Point(8, 3, 0, 0));
            quadTree.TryToInsert(new Point(8, 4, 0, 0));
            quadTree.TryToInsert(new Point(8, 5, 0, 0));
            quadTree.TryToInsert(new Point(8, 6, 0, 0));
            quadTree.TryToInsert(new Point(8, 7, 0, 0));
            quadTree.TryToInsert(new Point(8, 8, 0, 0));
            quadTree.TryToInsert(new Point(8, 9, 0, 0));

            quadTree.TryToInsert(new Point(9, 0, 0, 0));
            quadTree.TryToInsert(new Point(9, 1, 0, 0));
            quadTree.TryToInsert(new Point(9, 2, 0, 0));
            quadTree.TryToInsert(new Point(9, 3, 0, 0));
            quadTree.TryToInsert(new Point(9, 4, 0, 0));
            quadTree.TryToInsert(new Point(9, 5, 0, 0));
            quadTree.TryToInsert(new Point(9, 6, 0, 0));
            quadTree.TryToInsert(new Point(9, 7, 0, 0));
            quadTree.TryToInsert(new Point(9, 8, 0, 0));
            quadTree.TryToInsert(new Point(9, 9, 0, 0));
            /*try
            {
                // Read file using StreamReader. Reads file line by line    
                using (StreamReader file = new StreamReader("test.txt")) // (args[0])
                {
                    string ln;

                    while ((ln = file.ReadLine()) != null)
                    {
                        ln = ln.Replace(".", ",");
                        string[] tokens = ln.Split(' ');

                        double x = double.Parse(tokens[0]);
                        double y = double.Parse(tokens[1]);
                        double z = double.Parse(tokens[2]);
                        short i = short.Parse(tokens[3]);

                        Point point = new Point(x, y, z, i);

                        quadTree.TryToInsert(point);
                    }
                    file.Close();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        //}
        */

            DisplayQuadTree(quadTree);

            return 0;
        }

        static public void DisplayQuadTree(QuadTree q)
        {
            DisplayNodeWithChildren(q.Root);
        }

        private static void DisplayNodeWithChildren(Node node)
        {
            if(node.nodeType == NodeType.LEAF)
            {
                DisplayPoint(node.Point);
                return;
            }
            else if(node.nodeType == NodeType.BRANCH)
            {
                DisplayNodeWithChildren(node.NW);
                DisplayNodeWithChildren(node.NE);
                DisplayNodeWithChildren(node.SE);
                DisplayNodeWithChildren(node.SW);
                Console.WriteLine();
            }
        }

        private static void DisplayPoint(Point point)
        {
            Console.WriteLine(point.X + " " + point.Y + ": " + point.I);
        }
    }
}
