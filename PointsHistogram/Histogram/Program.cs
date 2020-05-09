using System;
using System.IO;

namespace Histogram
{
    class MainClass
    {
        public static int Main(string[] args)
        {
            if (args.Length < 8)
            {
                System.Console.WriteLine("Plese run program:\n program <preprocessed_file> <M> <minX> <maxX> <minY> <maxY> <bin_size> <selection>");
                return 1;
            }
            else
            {
                long NumberOfDataReads = 0;
                // read user parameters
                string fileName = args[0];
                int M = int.Parse(args[1]);
                // 38 461 points => 999 986 B => close to 1 M
                int maxSizeOfMemoryUsage = 999986 * M;

                double minX = Double.Parse(args[2]);
                double maxX = Double.Parse(args[3]);
                double minY = Double.Parse(args[4]);
                double maxY = Double.Parse(args[5]);
                int binSize = int.Parse(args[6]);
                char selection = char.Parse(args[7].ToLower());

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

                        byte[] chunk = reader.ReadBytes(maxSizeOfMemoryUsage);
                        NumberOfDataReads++;

                        int numOfPoints = 38461 / 2;
                        bool foundX = false;
                        bool foundlastX = false;
                        int indexOfFirstX = 0;

                        while(chunk.Length > 0)
                        {
                            int index = numOfPoints * 26;
                            if (foundX)
                                index = 0;

                            while (index < chunk.Length && index >= 0 && foundX == false)
                            {
                                double lastX = BitConverter.ToDouble(chunk, maxSizeOfMemoryUsage - 26);
                                if(lastX < minX)
                                {
                                    break;
                                }
                                double x = BitConverter.ToDouble(chunk, index); // 8 B
                                index += 26;

                                if (x >= minX && x <= maxX)
                                {
                                    foundX = true;
                                    indexOfFirstX = index;
                                }
                                else if(x < minX)
                                {
                                    numOfPoints = numOfPoints / 2;
                                    index += numOfPoints * 26;
                                }
                                else if(x > maxX)
                                {
                                    numOfPoints = numOfPoints / 2;
                                    index -= numOfPoints * 26;
                                }
                            }

                            if(foundX)
                            {
                                index -= 26;
                                while(index >= 0)
                                {
                                    double x = BitConverter.ToDouble(chunk, index); // 8 B
                                    if (x >= minX && x <= maxX)
                                    {
                                        indexOfFirstX = index;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                    index -= 26;
                                }
                                index += 26;
                            }

                            if(foundX)
                            {
                            
                                while(index < chunk.Length && foundlastX == false)
                                {
                                    double x = BitConverter.ToDouble(chunk, index); // 8 B
                                    index += 8;
                                    double y = BitConverter.ToDouble(chunk, index); // 8 B
                                    index += 8;
                                    double z = BitConverter.ToDouble(chunk, index); // 8 B
                                    index += 8;
                                    short i = BitConverter.ToInt16(chunk, index); // 2 B
                                    index += 2;
                                    //------
                                    // 26 B
                                    if (x >= minX && x <= maxX)
                                    {
                                       if(y >= minY && y <= maxY)
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
                                    else
                                    {
                                        foundlastX = true;
                                    }
                                }
                            }

                            if(foundlastX)
                            {
                                break;
                            }

                            chunk = reader.ReadBytes(maxSizeOfMemoryUsage);
                            NumberOfDataReads++;
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
