using System;
using System.Collections.Generic;
using System.Text;

namespace Statistic.Basic.DescriptiveStatistics
{
    public static class CorrelationCalculator
    {
        public static double Correlation(this IList<double> datasetX, IList<double> datasetY, CorrelationType correlationType)
        {

            if (datasetX.Count != datasetY.Count)
            {
                throw new ArgumentException("Inserted datasets have incompatible dimensions");
            }

            switch (correlationType)
            {
                case CorrelationType.Pearson:
                    return CalculatePearsonCorrelation(datasetX, datasetY);
                case CorrelationType.Spearman:
                    return 0; ;
                default:
                    throw new ArgumentException("The specified correlation is not supported");
            }
         
        }

        private static double CalculatePearsonCorrelation(IList<double> datasetX, IList<double> datasetY)
        {
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
