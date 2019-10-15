using System;
using System.Collections.Generic;

namespace Statistic.Basic
{
    public static class StatisticHelper
    {
        /// <summary>
        /// Given a dataset finds the absolute frequency for a specified range. The upper bound is exclusive
        /// </summary>
        /// <param name="dataset"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int GetAbsoluteFrequencyForInterval(this IList<double> dataset, double start, double end)
        {
            int result = 0;

            foreach(var data in dataset)
            {
                if (DataIsInRange(data, start, end))
                    result++;
            }

            return result;
        }

        public static List<int> GetAbsoluteFrequenciesForIntervals(this IList<double> dataset, IList<double> intervals)
        {
            return null;
        }

        private static bool DataIsInRange(double data, double start, double end)
        {
            return data >= start && data < end;
        }
    }
}
