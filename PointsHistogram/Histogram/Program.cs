using System;
using System.IO;
using QuadTree;

namespace Histogram
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // read data
            double minX = 394364;
            double maxX = 394374;
            double minY = 39150;
            double maxY = 39160;
            QuadTree.QuadTree quadTree = new QuadTree.QuadTree(minX, minY, maxX, maxY);
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
            // create histogram

            // statistics

            // output
        }
    }
}
