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
            int absoluteFrequency = 0;

            foreach(var data in dataset)
            {
                absoluteFrequency = IncreaseAbsFreqIfDataIsInRange(start, end, absoluteFrequency, data);
            }

            return absoluteFrequency;
        }

        private static int IncreaseAbsFreqIfDataIsInRange(double start, double end, int absoluteFrequency, double data)
        {
            if (DataIsInRange(data, start, end))
                absoluteFrequency++;
            return absoluteFrequency;
        }

        public static List<int> GetAbsoluteFrequenciesForIntervals(
            this IList<double> dataset, IList<double> intervals)
        {
            List<int> absoluteFrequencies = new List<int>();
            
            
            return absoluteFrequencies;
        }

        private static bool DataIsInRange(double data, double start, double end)
        {
            return data >= start && data < end;
        }
    }
}
