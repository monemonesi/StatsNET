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

        /// <summary>
        /// Given a dataset it calculates the variance.
        /// NOTE: As in R 1/(n-1) is used to calculate this value
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double Variance(this IList<double> dataset)
        {
            double mean = dataset.Mean();

            double sum = 0;

            foreach (double data in dataset)
            {
                sum += Math.Pow((data - mean), 2);
            }

            double variance = sum / (dataset.Count - 1);

            return variance;
        }

        /// <summary>
        /// Given a dataset it calculate the stadard deviation.
        /// NOTE: As in R 1/(n-1) is used to calculate this value
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double StandardDeviation(this IList<double> dataset)
        {
            return Math.Sqrt(dataset.Variance());
        }
    }
}
