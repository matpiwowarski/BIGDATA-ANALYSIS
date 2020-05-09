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
                long NumberOfDataReads = 0;
                // read user parameters
                string fileName = args[0];
                int M = int.Parse(args[1]);
                int B = int.Parse(args[2]);
                double minX = Double.Parse(args[3]);
                double maxX = Double.Parse(args[4]);
                double minY = Double.Parse(args[5]);
                double maxY = Double.Parse(args[6]);
                int binSize = int.Parse(args[7]);
                char selection = char.Parse(args[8].ToLower());

                SelectionType selectionType = SelectionType.I;
                if (selection == 'i')
                    selectionType = SelectionType.I;
                else if (selection == 'z')
                    selectionType = SelectionType.Z;

                // create histogram with bin size
                Histogram histogram = new Histogram(binSize);
                // create empty summary
                StatisticalSummary statisticalSummary = new StatisticalSummary();

                try
                {
                    using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            NumberOfDataReads++;
                            double x = reader.ReadDouble();
                            double y = reader.ReadDouble();
                            double z = reader.ReadDouble();
                            short i = reader.ReadInt16();

                            if (x >= minX && x <= maxX && y >= minY && y <= maxY)
                            {
                                if (selectionType == SelectionType.I)
                                {
                                    histogram.InsertValue(i);
                                }
                                else if (selectionType == SelectionType.Z)
                                {
                                    histogram.InsertValue(z);
                                }
                            }
                        }
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
                statisticalSummary.PrintReport(histogram.PointsCount, histogram.K, NumberOfDataReads);
                return 0;
            }
        }
    }
}
