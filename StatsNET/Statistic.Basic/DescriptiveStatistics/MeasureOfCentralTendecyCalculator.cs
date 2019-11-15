using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistic.Basic.DescriptiveStatistics
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
        /// Given a dataset it calculate the quartile
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static IList<double> Quantile(this IList<double> dataset)
        {

            List<double> percentages = new List<double> { 0.0, 0.25, 0.5, 0.75, 1 };

            return dataset.Quantile(percentages);

        }

        /// <summary>
        /// Given a dataset and specific percentages it calculate the quantile
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="percentages">Between 0 and 1</param>
        /// <returns></returns>
        public static IList<double> Quantile(this IList<double> dataset, IList<double> percentages)
        {
            CheckInputRange(percentages);

            IList<double> quantiles = new List<double>();
            IList<double> quantileIndexes = new List<double>();

            var orderedDataSet = dataset.OrderBy(d => d).ToList();

            foreach (var percentage in percentages)
            {
                CalculateQuantileForSpecificPercentage(quantiles, orderedDataSet, percentage);
            }

            return quantiles;
        }

        /// <summary>
        /// Given a dataset it calculate the mode as the value that appears with higher frequency
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static double Mode(this IList<double> dataset)
        {
            Dictionary<double, int> frequencies = new Dictionary<double, int>();

            foreach (var data in dataset)
            {
                if (!frequencies.ContainsKey(data))
                {
                    frequencies.Add(data, 1);
                }
                else
                {
                    frequencies[data]++;
                }
            }

            var mode = frequencies.OrderByDescending(freq => freq.Value).FirstOrDefault().Key;

            return mode;
        }

        private static void CheckInputRange(IList<double> percentages)
        {
            foreach (var num in percentages)
            {
                if (num < 0 || num > 1) throw new ArgumentOutOfRangeException("Percentages must be number between 0 and 1");
            }
        }

        private static void CalculateQuantileForSpecificPercentage(IList<double> quantiles, IList<double> orderedDataSet, double percentage)
        {
            var nAlpha = (orderedDataSet.Count * percentage);

            int quantileIndex = Math.Clamp((int)(nAlpha), 0, orderedDataSet.Count - 1);
            var quantile = orderedDataSet[quantileIndex];

            quantiles.Add(quantile);
        }

        private static bool IsNumOfObservationEven(IList<double> dataset)
        {
            return dataset.Count % 2 == 0;
        }
    }
}
