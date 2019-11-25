using NUnit.Framework;
using Statistic.Basic.DescriptiveStatistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Statistic.Basic.Tests.DescriptiveStatisticsTests
{
    [TestFixture]
    class CorrelationCalculatorTests : BaseTestClassHelper
    {

        [TestCase("-0,-1,-2,-3,-4,-5,-6,-7,-8,-9", "0,10,20,30,40,50,60,70,80,90", -1)]
        [TestCase("0,1,2,3,4,5,6,7,8,9", "0,10,20,30,40,50,60,70,80,90", 1)]
        public void PearsonCoefficientShouldReturnTheCorrectValue(string data1, string data2, double expected)
        {
            _dataSet1 = GivenASetOfData(data1);
            _dataset2 = GivenASetOfData(data2);

            _result = WhenPearsonCoefficientIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        private double WhenPearsonCoefficientIsCalculated()
        {
            return _dataSet1.Correlation(_dataset2, CorrelationType.Pearson);
        }
    }
}
