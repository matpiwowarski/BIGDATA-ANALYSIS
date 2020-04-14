using System;
using System.IO;

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

            Histogram histogram = new Histogram(5); // create histogram with bin size

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

                        if(x >= minX && x <= maxX && y >=minY && y <= maxY)
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
            // create histogram

            // statistics

            // output
        }
    }
}
