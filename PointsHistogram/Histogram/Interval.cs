using System;
using System.Collections.Generic;

namespace Histogram
{
    public class Interval
    {
        public double MinValue;
        public double MaxValue;
        public List<double> Values = new List<double>();

        public Interval(double min, double max)
        {
            MinValue = min;
            MaxValue = max;
        }

        public void Add(double value)
        {
            Values.Add(value);
        }
    }
}
