using System;
using System.Collections.Generic;
using System.Text;

namespace Statistic.Basic.DescriptiveStatistics
{
    public static class CorrelationCalculator
    {
        public static double Correlation(this IList<double> datasetX, IList<double> datasetY, CorrelationType type)
        {
            //TODO: Defensive code against possible exceptions (different lenghts, etc..)
            double meanX = datasetX.Mean();
            double meanY = datasetY.Mean();

            double numerator = 0.0;

            for (int i = 0; i < datasetX.Count; i++)
            {
                double x = datasetX[i];
                double y = datasetY[i];
                numerator += (x - meanX) * (y - meanY);
            }

            double denominatorX = 0.0;
            double denominatorY = 0.0;

            for (int i = 0; i < datasetX.Count; i++)
            {
                double x = datasetX[i];
                double y = datasetY[i];
                denominatorX += Math.Pow((x -meanX), 2);
                denominatorY += Math.Pow((y - meanY), 2);
            }

            return numerator / Math.Sqrt(denominatorX * denominatorY);
        }
    }
}
