using System;
using System.IO;

namespace QuadTree
{
    class MainClass
    {
        static int Count = 0;

        public static int Main(string[] args)
        {
            /*if (args.Length < 2)
            {
                System.Console.WriteLine("Plese run program:\n program <input_file.txt> <preprocessed_file>");
                return 1;
            }
            else
            {*/

            double minX = 394364;
            double maxX = 394374;
            double minY = 39150;
            double maxY = 39160;

            QuadTree quadTree = new QuadTree(minX, minY, maxX, maxY); 
            try
            {
                // Read file using StreamReader. Reads file line by line    
                using (StreamReader file = new StreamReader("Korte_Vegetation_all.txt")) // (args[0])
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

            DisplayQuadTree(quadTree);
            Console.WriteLine(Count);


            return 0;
        }

        static public void DisplayQuadTree(QuadTree q)
        {
            DisplayNodeWithChildren(q.Root);
        }

        private static void DisplayNodeWithChildren(Node node)
        {
            if(node.nodeType == NodeType.BRANCH)
            {
                DisplayNodeWithChildren(node.NW);
                DisplayNodeWithChildren(node.NE);
                DisplayNodeWithChildren(node.SE);
                DisplayNodeWithChildren(node.SW);
                Console.WriteLine();
            }
            else if (node.nodeType == NodeType.LEAF)
            {
                DisplayPoint(node.Point);
                return;
            }
        }

        private static void DisplayPoint(Point point)
        {
            Console.WriteLine(point.X + " " + point.Y + ": " + point.I);
            Count++;
        }
    }
}
