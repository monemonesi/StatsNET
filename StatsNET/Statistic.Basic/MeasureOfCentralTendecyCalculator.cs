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
            return dataset.Sum() / dataset.Count; 
        }

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
    }
}
