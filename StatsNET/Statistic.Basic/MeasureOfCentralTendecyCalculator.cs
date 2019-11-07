using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistic.Basic
{
    public static class MeasureOfCentralTendecyCalculator
    {
        /// <summary>
        /// Given a dataset it calculates the arithmetic mean
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double Mean(this IList<double> dataset)
        {
            return dataset.Sum() / dataset.Count; 
        }

        /// <summary>
        /// Given a dataset and its relativeFrequencies it calculates the weighted mean
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="relativeFreq"></param>
        /// <returns></returns>
        public static double WeightedMean(this IList<double> dataset, IList<double> relativeFreq)
        {
            if (dataset.Count != relativeFreq.Count)
                throw new ArgumentException("Each value in the dataset should have a relative frequency");

            double weighteMean = 0;

            for (int i = 0; i < dataset.Count; i++)
            {
                weighteMean += dataset[i] * relativeFreq[i];
            }

            return weighteMean;
        }

        /// <summary>
        /// Given a dataset it calculates the median
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double Median(this IList<double> dataset)
        {
            double median = 0;
            var orderedDataSet = dataset.OrderBy(d => d).ToList();

            if (IsNumOfObservationEven(dataset))
            {
                int midIndex = orderedDataSet.Count / 2;
                median = 0.5 * (orderedDataSet[midIndex - 1] + orderedDataSet[midIndex]);
            }
            else
            {
                int medianIndex = orderedDataSet.Count / 2;
                median = orderedDataSet[medianIndex];
            }

            return median;
        }

        /// <summary>
        /// Given a dataset it calculate the quantile
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static IList<double> Quantile(this IList<double> dataset)
        {

            List<double> percentages = new List<double> { 0.0, 0.25, 0.5, 0.75, 1 };

            return dataset.Quantile(percentages);

        }

        public static IList<double> Quantile(this IList<double> dataset, IList<double> percentages)
        {
            IList<double> quantiles = new List<double>();
            IList<double> quantileIndexes = new List<double>();

            var orderedDataSet = dataset.OrderBy(d => d).ToList();

            for (int i = 0; i < percentages.Count; i++)
            {
                var nAlpha = (orderedDataSet.Count * percentages[i]);

                int quantileIndex = Math.Clamp((int)(nAlpha), 0, orderedDataSet.Count-1);
                var quantile = orderedDataSet[quantileIndex];

                quantiles.Add(quantile);
            }

            return quantiles;
        }

        private static bool IsNumOfObservationEven(IList<double> dataset)
        {
            return dataset.Count % 2 == 0;
        }
    }
}
