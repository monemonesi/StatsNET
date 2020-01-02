using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statistic.Basic.DescriptiveStatistics
{
    public static class CorrelationCalculator
    {
        public static double Correlation(this IList<double> datasetX, IList<double> datasetY, CorrelationType correlationType)
        {

            if (datasetX.Count != datasetY.Count)
            {
                throw new ArgumentException("Datasets should have the same dimensions");
            }

            switch (correlationType)
            {
                case CorrelationType.Pearson:
                    return CalculatePearsonCorrelation(datasetX, datasetY);
                case CorrelationType.Spearman:
                    return CalculateSpearmanRankCorrelation(datasetX, datasetY);
                default:
                    throw new ArgumentException("The specified correlation is not supported");
            }
         
        }

        //TODO: Spearman rank should be calculated using covar formula: https://en.wikipedia.org/wiki/Spearman%27s_rank_correlation_coefficient
        //TODO: https://en.wikipedia.org/wiki/Covariance , https://en.wikipedia.org/wiki/Ranking#Fractional_ranking_.28.221_2.5_2.5_4.22_ranking.29
        private static double CalculateSpearmanRankCorrelation(IList<double> datasetX, IList<double> datasetY)
        {
            var rankX = datasetX.GetRank();
            var rankY = datasetY.GetRank();

            double numerator = CalculateSpearmanNumerator(rankX, rankY);

            double denominator = CalculateSpearmanDenominator(datasetX.Count());

            var result = 1 - (numerator / denominator);
            return result;
        }

        private static double CalculateSpearmanDenominator(int n)
        {
            return n * (n * n - 1);
        }

        private static double CalculateSpearmanNumerator(IList<double> rankX, IList<double> rankY)
        {
            double denominator = 0.0;

            for (int i = 0; i < rankX.Count; i++)
            {
                denominator += Math.Pow(rankX[i] - rankY[i],2);
            }

            return 6 * denominator; 
        }

        private static double CalculatePearsonCorrelation(IList<double> datasetX, IList<double> datasetY)
        {
            double meanX = datasetX.Mean();
            double meanY = datasetY.Mean();

            double numerator = 0.0;
            double denominatorX = 0.0;
            double denominatorY = 0.0;

            for (int i = 0; i < datasetX.Count; i++)
            {
                double x = datasetX[i];
                double y = datasetY[i];

                numerator += (x - meanX) * (y - meanY);

                denominatorX += Math.Pow((x - meanX), 2);
                denominatorY += Math.Pow((y - meanY), 2);
            }

            return numerator / (Math.Sqrt(denominatorX * denominatorY));
        }

    }
}
