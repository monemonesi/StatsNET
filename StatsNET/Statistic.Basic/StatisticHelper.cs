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
        /// Dictionary sorted by intervals with the absolute frequencies
        /// </returns>
        public static Dictionary<double, double> GetAbsoluteFrequenciesForIntervals(
            this IList<double> dataset, IList<double> intervals)
        {
            Dictionary<double, double> absoluteFrequencies = new Dictionary<double, double>();
            IList<double> sortedDataset = dataset.OrderBy(m => m).ToList();
            IList<double> sortedIntervals = intervals.OrderBy(m => m).ToList();

            for (int i = 1; i < sortedIntervals.Count; i++)
            {
                var start = sortedIntervals[i-1];
                var end = intervals[i];

                absoluteFrequencies.TryAdd(end, 0);

                foreach (var data in sortedDataset)
                {
                    CalculateAbsoluteFrequency(absoluteFrequencies, start, end, data);
                }

            }         
            
            return absoluteFrequencies;
        }

        /// <summary>
        /// Given a Dataset and a series of intervals return the relative frequencies for the requested intervals.
        /// The Upper bound is exclusive
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="intervals"></param>
        /// <param name="roundTo"></param>
        /// <returns name ="relativeFrequencies">
        /// Dictionary sorted by intervals with the absolute frequencies
        /// </returns>
        public static Dictionary<double,double> GetRelativeFrequenciesForIntervals(
            this IList<double> dataset, IList<double> intervals, int roundTo)
        {
            Dictionary<double,double> absoluteFrequencies = dataset.GetAbsoluteFrequenciesForIntervals(intervals);
            Dictionary<double, double> relativeFrequencies = new Dictionary<double, double>();
            int samples = dataset.Count();

            foreach (var key in absoluteFrequencies.Keys)
            {
                relativeFrequencies[key] = Math.Round(absoluteFrequencies[key]/samples, roundTo);
            }

            return relativeFrequencies;
        }

        private static void CalculateAbsoluteFrequency(Dictionary<double, double> absoluteFrequencies, double start, double end, double data)
        {
            if (DataIsInRange(data, start, end))
                absoluteFrequencies[end]++;
        }

        private static bool DataIsInRange(double data, double start, double end)
        {
            return data >= start && data < end;
        }
    }
}
