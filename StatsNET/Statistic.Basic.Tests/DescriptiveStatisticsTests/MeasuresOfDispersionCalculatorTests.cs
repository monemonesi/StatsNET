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

        [TestCase("22.5,24.3,21.6,30.6,35.7", 6.027)]
        [TestCase("22,22,22,22,22,22", 0)]
        [TestCase("-10,4,0,-15,4,5.5", 8.546)]
        [TestCase("22,24,21,30,28,29", 3.829)]
        [TestCase("1,1,1,1", 0)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26", 1.723)]
        public void StandardDeviationShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenTheStandardDeviationIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        [TestCase("30,25,12,45,50,52,38,39,45,33", "-0.561,-0.968,-2.025,0.659,1.065,1.228,0.089,0.171,0.659,-0.312")]
        [TestCase("22.5,24.3,21.6,30.6,35.7", "-0.737,-0.438,-0.886,0.607,1.453")]
        [TestCase("-10,4,0,-15,4,5.5", "-0.946,0.692,0.224,-1.531,0.692,0.868")]
        public void StandardizeMethodShouldReturnTheStandardizedSetOfValues(string data, string expected)
        {
            _dataSet = GivenASetOfData(data);
            _expectedValues = GivenASetOfData(expected);

            _resultingDataset = WhenTheStandardizedValuesAreCalculated();

            ThenItShouldReturnTheExpectedValues(_resultingDataset, _expectedValues);
        }

        [Test]
        public void StandardizedMethodShouldThrownAnExceptionWhenDatasetHasStandardDeviationEqualZero()
        {
            _dataSet = new List<double>() { 22.0,22.0,22.0,22.0};

            ThenStandardizeShouldThrownAnException();
        }

        [TestCase("22,24,21,30,28,29", 0.149)]
        [TestCase("1,1,1,1", 0)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26", 0.071)]
        public void CoefficientOfVariationShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenCoefficietOfVariationIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        [Test]
        public void CoefficientOfVariationShouldThrownAnExceptionWhenTheMeanIs0()
        {
            _dataSet = new List<double> { -1, 1 };

            ThenCoefficentOfVariationShouldThrownAnException();
        }

        private void ThenCoefficentOfVariationShouldThrownAnException()
        {
            Assert.Throws<DivideByZeroException>(() => WhenCoefficietOfVariationIsCalculated());
        }

        private double WhenCoefficietOfVariationIsCalculated()
        {
            return _dataSet.CoefficientOfVariation();
        }

        private void ThenStandardizeShouldThrownAnException()
        {
            Assert.Throws<DivideByZeroException>(() => WhenTheStandardizedValuesAreCalculated());
        }

        private IList<double> WhenTheStandardizedValuesAreCalculated()
        {
            return _dataSet.Standardize();
        }

        private double WhenTheStandardDeviationIsCalculated()
        {
            return _dataSet.StandardDeviation();
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
