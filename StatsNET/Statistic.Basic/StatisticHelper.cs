using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistic.Basic
{
    public static class StatisticHelper
    {

        /// <summary>
        /// Given a Dataset and a series of intervals return the absolute frequencies for the requested intervals.
        /// The Upper bound is exclusive
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="intervals"></param>
        /// <returns name="AbsoluteFrequencies">
        /// Dicitionary sorted by intervals with the absolute frequencies
        /// </returns>
        public static Dictionary<double, int> GetAbsoluteFrequenciesForIntervals(
            this IList<double> dataset, IList<double> intervals)
        {
            Dictionary<double, int> absoluteFrequencies = new Dictionary<double, int>();
            IList<double> sortedDataset = dataset.OrderBy(m => m).ToList();
            IList<double> sortedIntervals = intervals.OrderBy(m => m).ToList();

            for (int i = 1; i < sortedIntervals.Count; i++)
            {
                var start = sortedIntervals[i-1];
                var end = intervals[i];

                absoluteFrequencies.TryAdd(end, 0);

                foreach (var data in sortedDataset)
                {

                    if (data < end)
                    {
                        if (DataIsInRange(data, start, end))
                        {
                            absoluteFrequencies[end]++;
                        }
                    }

                }
                
            }         
            
            return absoluteFrequencies;
        }

        private static bool DataIsInRange(double data, double start, double end)
        {
            return data >= start && data < end;
        }
    }
}
