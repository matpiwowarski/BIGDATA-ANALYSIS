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

        public void PrintReport(int pointsCount)
        {
            Console.WriteLine("Number of points inside given bounding box: " + pointsCount);
            Console.WriteLine("Calculated average: " + AverageValue);
            Console.WriteLine("Calculated deviation: " + StandardDeviation);
            Console.WriteLine("Calculated skewness: " + Skewness);
            Console.WriteLine("Calculated kurtosis: " + Kurtosis);
        }
    }
}
