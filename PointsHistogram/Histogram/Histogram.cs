using System;
using System.Collections.Generic;

namespace Histogram
{
    public class Histogram
    {
        public int BinSize = 0;
        public int PointsCount { get => Values.Count; }
        public double Min = double.MaxValue; 
        public double Max = double.MinValue;

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
            statisticalSummary.StandardDeviation = CalculateStandardDeviation();
            statisticalSummary.Skewness = CalculateSkewness();
            statisticalSummary.Kurtosis = CalculateKurtosis();
        }

        private double CalculateKurtosis()
        {
            return 0;
        }

        private double CalculateSkewness()
        {
            return 0;
        }

        private double CalculateStandardDeviation()
        {
            return 0;
        }

        private double CalculateAverageValue()
        {
            return 0;
        }
    }
}
