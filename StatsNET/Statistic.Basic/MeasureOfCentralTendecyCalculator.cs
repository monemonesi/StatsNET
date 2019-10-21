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

        public static double Median(this IList<double> dataset)
        {
            double median = 0;
            var orderedDataSet = dataset.OrderBy(d => d).ToList();
            bool numOfObservationIsEven = dataset.Count % 2 == 0;

            if (numOfObservationIsEven)
            {
                int midIndex = orderedDataSet.Count / 2;
                median = 0.5 * (orderedDataSet[midIndex-1] + orderedDataSet[midIndex]);
            }
            else
            {
                int medianIndex = orderedDataSet.Count / 2;
                median = orderedDataSet[medianIndex];
            }

            return median;
        }
    }
}
