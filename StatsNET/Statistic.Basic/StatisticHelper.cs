using System;
using System.Collections.Generic;

namespace Statistic.Basic
{
    public static class StatisticHelper
    {
        public static int GetAbsoluteFrequencyInRange(this IList<double> dataset, double start, double end)
        {
            int result = 0;

            foreach(var data in dataset)
            {
                if (DataIsInRange(data, start, end))
                    result++;
            }

            return result;
        }

        private static bool DataIsInRange(double data, double start, double end)
        {
            return data >= start && data < end;
        }
    }
}
