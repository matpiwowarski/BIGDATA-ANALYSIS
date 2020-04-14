using System;
namespace Histogram
{
    public class StatisticalSummary
    {
        public double AverageValue;
        public double StandardDeviation;
        public double Skewness;
        public double Kurtosis;

        public StatisticalSummary()
        {

        }

        public void PrintReport(int pointsCount, long dataReads)
        {
            Console.WriteLine("Number of points inside given bounding box: " + pointsCount);
            Console.WriteLine("Calculated average: " + Math.Round(AverageValue, 4));
            Console.WriteLine("Calculated deviation: " + Math.Round(StandardDeviation, 5));
            Console.WriteLine("Calculated skewness: " + Math.Round(Skewness, 5));
            Console.WriteLine("Calculated kurtosis: " + Math.Round(Kurtosis, 5));
            Console.WriteLine("Number of data reads from the input file: " + dataReads);
        }
    }
}
