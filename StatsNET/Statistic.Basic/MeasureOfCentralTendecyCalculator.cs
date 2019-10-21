using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistic.Basic
{
    public static class MeasureOfCentralTendecyCalculator
    {
        public static double Mean(this IList<double> dataset)
        {
            double mean = dataset.Sum() / dataset.Count; 

            return mean;
        }
    }
}
