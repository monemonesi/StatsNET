using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistic.Basic.DescriptiveStatistics
{
    public static class MeasuresOfDispersionCalculator
    {
        /// <summary>
        /// Given a dataset it calculates the range of the values in it
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double Range(this IList<double> dataset)
        {
            var orderedDatasetDescending = dataset.OrderByDescending(d => d).ToList();

            return orderedDatasetDescending.FirstOrDefault() - orderedDatasetDescending[orderedDatasetDescending.Count - 1];
        }

        /// <summary>
        /// Given a dataset it calculates the interquartile as the difference between
        /// quartile(0.75) - quartile(0.25)
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double InterQuartile(this IList<double> dataset)
        {
            var quartiles = dataset.Quantile();
            return quartiles[3] - quartiles[1];
        }
    }
}
