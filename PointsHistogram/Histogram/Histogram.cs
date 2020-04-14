using System;
using System.Collections.Generic;

namespace Histogram
{
    public class Histogram
    {
        public int BinSize = 0;
        public double Min = double.MaxValue; 
        public double Max = double.MinValue;
        public int PointsCount { get => Values.Count; }
        public int K { get => Intervals.Count; }

        public List<double> Values = new List<double>();
        public List<Interval> Intervals = new List<Interval>();

        public Histogram(int binSize)
        {
            BinSize = binSize;
        }

        public void InsertValue<T>(T value)
        {
            double v = Convert.ToDouble(value);

            if (v < Min)
            {
                Min = v;
            }

            if (v > Max)
            {
                Max = v;
            }

            Values.Add(v);
        }

        public void CreateIntervals()
        {
            double minIntervalValue = Min - BinSize;
            double maxIntervalValue = Min;

            do
            {
                minIntervalValue += BinSize;
                maxIntervalValue += BinSize;
                Intervals.Add(new Interval(minIntervalValue, maxIntervalValue));
            }
            while (maxIntervalValue <= Max);

            CalculateIntervalsH();
            CalculateIntervalsValues();
        }

        private void CalculateIntervalsValues()
        {
            foreach(Interval i in Intervals)
            {
                i.Val = i.MinValue + BinSize / 2;
            }
        }

        private void CalculateIntervalsH()
        {
            foreach(double v in Values)
            {
                foreach(Interval i in Intervals)
                {
                    if(v >= i.MinValue && v < i.MaxValue)
                    {
                        i.H++;
                    }
                }
            }
        }

        public void MakeSummary(StatisticalSummary statisticalSummary)
        {

            statisticalSummary.AverageValue = CalculateAverageValue();
            statisticalSummary.StandardDeviation = CalculateStandardDeviation(statisticalSummary.AverageValue);
            statisticalSummary.Skewness = CalculateSkewness(statisticalSummary.AverageValue);
            statisticalSummary.Kurtosis = CalculateKurtosis(statisticalSummary.AverageValue);
        }

        private double CalculateAverageValue()
        {
            double nominator = 0;
            double denominator = 0;

            for(int k = 0; k < K; k++)
            {
                nominator += Intervals[k].Val * Intervals[k].H;
                denominator += Intervals[k].H;
            }

            double average = nominator / denominator;

            return average;
        }

        private double CalculateStandardDeviation(double averageValue)
        {
            double nominator = 0;
            double denominator = 0;

            for (int k = 0; k < K; k++)
            {
                nominator += Intervals[k].H * Math.Pow((Intervals[k].Val - averageValue), 2);
                denominator += Intervals[k].H;
            }

            double deviation = Math.Sqrt(nominator / denominator);
            return deviation;
        }

        private double CalculateSkewness(double averageValue)
        {
            double topNominator = 0;
            double botNominator = 0;
            double topDenominator = 0;
            double botDenominator = 0;

            for (int k = 0; k < K; k++)
            {
                topNominator += Intervals[k].H * Math.Pow((Intervals[k].Val - averageValue), 3);
                topDenominator += Intervals[k].H;
                botNominator += Intervals[k].H * Math.Pow((Intervals[k].Val - averageValue), 2);
                botDenominator += Intervals[k].H;
            }

            botDenominator--; // -1

            double mainNominator = topNominator / topDenominator;
            double mainDenominator = Math.Pow(botNominator / botDenominator, 1.5);

            double skweness = mainNominator / mainDenominator;

            return skweness;
        }

        private double CalculateKurtosis(double averageValue)
        {
            double leftFactor = 0;
            double nominator = 0;
            double denominator = 0;

            for (int k = 0; k < K; k++)
            {
                leftFactor += Intervals[k].H; // ok

                double difference = Intervals[k].Val - averageValue;

                nominator += Intervals[k].H * Math.Pow(difference, 4);
                denominator += Intervals[k].H * Math.Pow(difference, 2); // ok
            }

            denominator = Math.Pow(denominator, 2);

            nominator = leftFactor * nominator;

            double kurtosis = nominator / denominator;

            return kurtosis;
        }
    }
}
