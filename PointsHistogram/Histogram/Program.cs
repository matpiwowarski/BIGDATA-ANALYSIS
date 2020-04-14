using System;
using System.IO;

namespace Histogram
{
    class MainClass
    {
        public static int Main(string[] args)
        {
            if (args.Length < 9)
            {
                System.Console.WriteLine("Plese run program:\n program <preprocessed_file> <M> <B> <minX> <maxX> <minY> <maxY> <bin_size> <selection>");
                return 1;
            }
            else
            {
                // read user parameters
                var fileName = args[0];
                var M = int.Parse(args[1]);
                var B = int.Parse(args[2]);
                var minX = Double.Parse(args[3]);
                var maxX = Double.Parse(args[4]);
                var minY = Double.Parse(args[5]);
                var maxY = Double.Parse(args[6]);
                var binSize = int.Parse(args[7]);
                var selection = char.Parse(args[8].ToLower());

                SelectionType selectionType;
                if (selection == 'i')
                    selectionType = SelectionType.I;
                else if (selection == 'z')
                    selectionType = SelectionType.Z;

                // create histogram with bin size
                Histogram histogram = new Histogram(5);
                // create empty summary
                StatisticalSummary statisticalSummary = new StatisticalSummary();

                try
                {
                    // Read file using StreamReader. Reads file line by line    
                    using (StreamReader file = new StreamReader("Korte_Vegetation_all.txt"))
                    {
                        string ln;

                        while ((ln = file.ReadLine()) != null)
                        {
                            ln = ln.Replace(".", ",");
                            string[] tokens = ln.Split(' ');

                            double x = double.Parse(tokens[0]);
                            double y = double.Parse(tokens[1]);

                            if (x >= minX && x <= maxX && y >= minY && y <= maxY)
                            {
                                short i = short.Parse(tokens[3]);
                                histogram.InsertValue(i);
                            }
                        }
                        file.Close();
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

                // statistics
                histogram.CreateIntervals();
                histogram.MakeSummary(statisticalSummary);

                // output
                statisticalSummary.PrintReport(histogram.PointsCount);
                return 0;
            }
        }
    }
}
