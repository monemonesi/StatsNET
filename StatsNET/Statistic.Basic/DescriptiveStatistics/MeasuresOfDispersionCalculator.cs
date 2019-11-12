using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistic.Basic.DescriptiveStatistics
{
    public static class MeasuresOfDispersionCalculator
    {
        public static double Range(this IList<double> dataset)
        {
            var orderedDatasetDescending = dataset.OrderByDescending(d => d).ToList();

            return orderedDatasetDescending.FirstOrDefault() - orderedDatasetDescending[orderedDatasetDescending.Count - 1];
        }
    }
}
