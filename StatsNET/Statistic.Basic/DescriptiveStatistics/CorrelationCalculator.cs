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

            double numerator = CalculateNumerator(datasetX, datasetY, meanX, meanY);
            double denominator = CalculateDenominator(datasetX, datasetY, meanX, meanY);

            return numerator / denominator;
        }

        private static double CalculateDenominator(IList<double> datasetX, IList<double> datasetY, double meanX, double meanY)
        {
            double denominatorX = 0.0;
            double denominatorY = 0.0;

            for (int i = 0; i < datasetX.Count; i++)
            {
                double x = datasetX[i];
                double y = datasetY[i];
                denominatorX += Math.Pow((x - meanX), 2);
                denominatorY += Math.Pow((y - meanY), 2);
            }

            return Math.Sqrt(denominatorX * denominatorY);
            
        }

        private static double CalculateNumerator(IList<double> datasetX, IList<double> datasetY, double meanX, double meanY)
        {
            double numerator = 0.0;

            for (int i = 0; i < datasetX.Count; i++)
            {
                double x = datasetX[i];
                double y = datasetY[i];
                numerator += (x - meanX) * (y - meanY);
            }

            return numerator;
        }
    }
}
