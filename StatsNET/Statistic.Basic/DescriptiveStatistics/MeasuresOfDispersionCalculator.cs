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

        public static double Covariance(this IList<double> datasetX, IList<double> datasetY)
        {
            double meanX = datasetX.Mean();
            double meanY = datasetY.Mean();

            double sum = 0;

            for (int i = 0; i < datasetX.Count(); i++)
            {
                sum += (datasetX[i] - meanX) * (datasetY[i] - meanY);
            }

            double covariance = sum / (datasetX.Count - 1);
            
            return covariance;
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

        /// <summary>
        /// Given a dataset it calculates the standardized values, considering mean = 0 and standardDeviation = 1
        /// NOTE: As in R 1/(n-1) is used to calculate this value
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static List<double> Standardize(this IList<double> dataset) 
        {
            double mean = dataset.Mean();
            double standardDeviation = dataset.StandardDeviation();

            if(standardDeviation.IsZero()) {
                throw new DivideByZeroException("In order to obtain standardized values the dataset must have standard deviation different from 0");
            }

            List<double> standardizedValues = new List<double>();

            foreach (var value in dataset)
            {
                standardizedValues.Add((value - mean) / standardDeviation);
            }

            return standardizedValues;
        }

        /// <summary>
        /// Given a dataset it calculate the coefficient of variation as:
        /// Coefficient of Variation = standardDeviation / mean
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double CoefficientOfVariation(this IList<double> dataset)
        {
            if (dataset.Mean().IsZero())
            {
                throw new DivideByZeroException("In order to calculate the coefficient of variation the mean must not be 0");
            }

            return (dataset.StandardDeviation() / dataset.Mean());
        }

        private static bool IsZero(this double value)
        {
            return Math.Abs(value) <= 0.00000001;
        }
    }
}
