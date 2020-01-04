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

        private static double CalculateSpearmanRankCorrelation(IList<double> datasetX, IList<double> datasetY)
        {
            var rankX = datasetX.GetRank();
            var rankY = datasetY.GetRank();

            double covar = MeasuresOfDispersionCalculator.Covariance(rankX, rankY);

            double standardDeviationX = rankX.StandardDeviation();
            double standardDeviationY = rankY.StandardDeviation();

            double spermanRankCorr = covar / (standardDeviationX * standardDeviationY);

            return spermanRankCorr;

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
