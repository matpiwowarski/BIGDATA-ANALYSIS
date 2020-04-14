using System;
using System.Collections.Generic;

namespace Histogram
{
    public class Interval
    {
        public double MinValue;
        public double MaxValue;

        public int H = 0;
        public double Val;

        public Interval(double min, double max)
        {
            MinValue = min;
            MaxValue = max;
        }
    }
}
