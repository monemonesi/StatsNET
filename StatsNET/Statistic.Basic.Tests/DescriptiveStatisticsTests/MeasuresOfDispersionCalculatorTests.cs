using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Statistic.Basic.DescriptiveStatistics;

namespace Statistic.Basic.Tests.DescriptiveStatisticsTests
{
    [TestFixture]
    class MeasuresOfDispersionCalculatorTests : BaseTestClassHelper
    {

        [TestCase("4,-2,5,0", 7)]
        [TestCase("6,6,6,6",0)]
        [TestCase("0,1.5,-0.5,10.98",11.48)]
        public void RangeShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenTheRangeIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        [TestCase("1,0,2,3,4",2)]
        [TestCase("0,-0,0,-0,0",0)]
        [TestCase("1,3",2)]
        [TestCase("-10,4,0,-15,4,5.5",14)]
        public void InterquartileRangeShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenTheInterquartileIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        [TestCase("22.5,24.3,21.6,30.6,35.7", 36.333)]
        [TestCase("22,22,22,22,22,22",0)]
        [TestCase("-10,4,0,-15,4,5.5", 73.041)]
        public void VarianceShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenTheVarianceIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        private double WhenTheVarianceIsCalculated()
        {
            return _dataSet.Variance();
        }

        private double WhenTheInterquartileIsCalculated()
        {
            return _dataSet.InterQuartile();
        }

        private double WhenTheRangeIsCalculated()
        {
            return _dataSet.Range();
        }
    }
}
