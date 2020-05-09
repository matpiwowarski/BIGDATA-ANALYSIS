using System;
using System.Collections.Generic;
using System.IO;

namespace QuadTree
{
    class MainClass
    {
        public static int Main(string[] args)
        {
            if (args.Length < 2)
            {
                System.Console.WriteLine("Plese run program:\n program <input_file.txt> <preprocessed_file>");
                return 1;
            }
            else
            {
                var inputFileName = args[0];
                var outputFileName = args[1];

                SortedDictionary<double, Point> sortedPoints = new SortedDictionary<double, Point>(new DuplicateKeyComparer<double>());

                try
                {
                    // Read file using StreamReader. Reads file line by line    
                    using (StreamReader file = new StreamReader(inputFileName)) // (args[0])
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

                            sortedPoints.Add(point.X, point);
                        }
                        file.Close();
                    }

                    // save sorted list in binary file
                    SaveToBinaryFile(sortedPoints);
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }

            return 0;
        }

        private static void SaveToBinaryFile(SortedDictionary<double, Point> sortedPoints)
        {
            
        }

        private static void DisplayPointList(SortedDictionary<double, Point> sortedPoints)
        {
            foreach(var p in sortedPoints)
            {
                Console.WriteLine(p.Value.X + "   " + p.Value.Y);
            }
        }

        private static void DisplayPoint(Point point)
        {
            Console.WriteLine(point.X + " " + point.Y + ": " + point.I);
        }
    }
}
