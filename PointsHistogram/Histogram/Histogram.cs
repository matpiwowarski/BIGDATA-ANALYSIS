﻿using System;
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
            statisticalSummary.StandardDeviation = CalculateStandardDeviation();
            statisticalSummary.Skewness = CalculateSkewness();
            statisticalSummary.Kurtosis = CalculateKurtosis();
        }

        private double CalculateAverageValue()
        {
            double nominator = 0;
            double denominator = 0;

            for(int k = 0; k < K; k++)
            {
                nominator += Intervals[k].Val * Intervals[k].H;
            }

            for (int k = 0; k < K; k++)
            {
                denominator += Intervals[k].H;
            }

            double average = nominator / denominator;

            return average;
        }

        private double CalculateStandardDeviation()
        {
            double nominator = 0;
            double denominator = 0;

            double deviation = Math.Sqrt(nominator / denominator);
            return deviation;
        }

        private double CalculateKurtosis()
        {
            return 0;
        }

        private double CalculateSkewness()
        {
            return 0;
        }
    }
}
