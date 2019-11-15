using NUnit.Framework;
using System;
using System.Collections.Generic;
using Statistic.Basic.DescriptiveStatistics;

namespace Statistic.Basic.Tests.DescriptiveStatisticsTests
{
    [TestFixture]
    class MeasureOfCentralTendecyCalculatorTests : BaseTestClassHelper
    {
        
        private IList<double> _relativeFrequencies, _percentages;

        [TestCase("22,24,21,30,28,29", 25.66667)]
        [TestCase("1,1,1,1",1)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26",24.4)]
        public void ArithmeticMeanShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenTheMeanIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);

        }

        [TestCase("22,24,21,30,28,29")]
        [TestCase("1,1,1,1")]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26")]
        public void ArithmeticMeanProperties(string data)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenTheMeanIsCalculated();

            ThenTheSumOfTheDeviationOfEachVariableShoulbBeZero(_result);
        }

        [TestCase("22.5,27.5,32.5","0.37, 0.58, 0.05",25.9)]
        public void WeightedMeanShouldReturnTheCorrectValue(string data, string relativeFrequencies, double expected)
        {
            _dataSet = GivenASetOfData(data);
            _relativeFrequencies =GivenASetOfData(relativeFrequencies);

            _result = WhenWeightedMeanIsCalculated();

            Assert.AreEqual(_result, expected);
        }

        [TestCase("22.5,27.5,32.5", "0.37")]
        public void WeightedMeanShouldReturnAnExceptionWhenDataIsIncorrect(string data, string relativeFrequencies)
        {
            _dataSet = GivenASetOfData(data);
            _relativeFrequencies = GivenASetOfData(relativeFrequencies);

            ThenAnExceptionShouldBeThrown();
        }

        [TestCase("22.46,24.1,21.78,30.954", 23.28)]
        [TestCase("22,24,21,30,28", 24)]
        [TestCase("22,24,21,30,28,29",26)]
        [TestCase("22,21.18,15.98,24,21,30,28,29,29,29,29", 28)]
        [TestCase("-22,-24.67,-21.9,30.21,28,29",3.05)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26",25)]
        public void TheMedianShouldReturnTheCorrectValue(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = WhenMedianIsCalculated();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }

        [TestCase("22.46,24.1,21.78,30.954,35.00", "21.78,22.46,24.1,30.954,35.00")]
        [TestCase("22,24,21,30,35", "21,22,24,30,35")]
        [TestCase("22.5,24.3,21.6,30.6,35.7", "21.6,22.5,24.3,30.6,35.7")]
        public void TheQuantileShoulReturnTheCorrectQuartileValueIfNoOptionIsSpecified(string data, string expected)
        {
            _dataSet = GivenASetOfData(data);
            _expectedValues = GivenASetOfData(expected);

            _resultingDataset = WhenQuantilesAreCalculated();

            ThenItShouldReturnTheExpectedValues(_resultingDataset, _expectedValues);

        }

        [TestCase("21,22,22,23,24,24,25,25,25,25,25,25,26,26,26,26,27,27,27,28,28,28,29,29,29,29,29,30,30,30,31", "21,25,26,29,31")]
        [TestCase("26,22,22,23,24,24,25,25,25,25,29,25,21,27,26,26,27,27,26,28,31,28,25,29,29,29,29,30,30,30,28", "21,25,26,29,31")]
        public void TheQuantileShouldReturnQuartileValuesIfNoOptionIsSoecifiedAndWithDuplicateNumber(string data, string expected)
        {
            _dataSet = GivenASetOfData(data);
            _expectedValues = GivenASetOfData(expected);

            _resultingDataset = WhenQuantilesAreCalculated();

            ThenItShouldReturnTheExpectedValues(_resultingDataset, _expectedValues);
        }

        [TestCase("22,24,21,30,35", "0.25,0.75" ,"22,30")]
        [TestCase("22.5,24.3,21.6,30.6,35.7", "0", "21.6")]
        [TestCase("22.5,24.3,21.6,30.6,35.7", "1", "35.7")]
        [TestCase("22,22,22,22", "0", "22")]
        [TestCase("22", "0", "22")]
        [TestCase("22", "1", "22")]
        public void QuantileShouldAllowCustomOption(string data, string percentile, string expected)
        {
            _dataSet = GivenASetOfData(data);
            _percentages = GivenASetOfData(percentile);
            _expectedValues = GivenASetOfData(expected);

            _resultingDataset = WhenQuantileAreCalculatedWithSpecificPercentages();

            ThenItShouldReturnTheExpectedValues(_resultingDataset, _expectedValues);
        }

        [TestCase("22,-24,-21,30,35", "0.25,0.75", "-21,30")]
        [TestCase("22.5,24.3,21.6,30.6,-35.7", "0", "-35.7")]
        [TestCase("22.5,-24.3,-21.6,30.6,35.7", "1", "35.7")]
        [TestCase("-22,-22,-22,-22", "0", "-22")]
        public void QuatileShouldReturnTheCorrectValueWhenNegativeValueInDataset(string data, string percentile, string expected)
        {
            _dataSet = GivenASetOfData(data);
            _percentages = GivenASetOfData(percentile);
            _expectedValues = GivenASetOfData(expected);

            _resultingDataset = WhenQuantileAreCalculatedWithSpecificPercentages();

            ThenItShouldReturnTheExpectedValues(_resultingDataset, _expectedValues);
        }

        [TestCase("22,-24,-21,30,35", "-0.25,0.75")]
        public void QuantileShouldThrownAnExceptionWhenPercantagesAreOutOfRange0To1(string data, string percentile)
        {
            _dataSet = GivenASetOfData(data);
            _percentages = GivenASetOfData(percentile);

            ThenAnExceptionShouldBeThrownFromQuantileFunction();
        }

        [TestCase("0,-1,2,2", 2)]
        [TestCase("-1,-0,0.05,-1,0,-1.0",-1)]
        [TestCase("-1,-0,0.05,-1,0,0.0", 0)]
        public void ModeShouldReturnTheValueWithMaxFrequency(string data, double expected)
        {
            _dataSet = GivenASetOfData(data);

            _result = _dataSet.Mode();

            ThenItShouldReturnTheExpectedValue(_result, expected);
        }


        private IList<double> WhenQuantileAreCalculatedWithSpecificPercentages()
        {
            return _dataSet.Quantile(_percentages);
        }

        private IList<double> WhenQuantilesAreCalculated()
        {
            return _dataSet.Quantile();
        }

        private double WhenMedianIsCalculated()
        {
            return Math.Round(_dataSet.Median(),5);
        }

        private void ThenTheSumOfTheDeviationOfEachVariableShoulbBeZero(double mean)
        {
            double deviationsSum = 0;
            foreach (var data in _dataSet)
            {
                deviationsSum += (data - mean);
            }

            Assert.AreEqual(0, Math.Round(deviationsSum, 4));
        }

        private void ThenAnExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentException>(() => WhenWeightedMeanIsCalculated());
        }

        private void ThenAnExceptionShouldBeThrownFromQuantileFunction()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => WhenQuantileAreCalculatedWithSpecificPercentages());
        }

        private double WhenWeightedMeanIsCalculated()
        {
            return _dataSet.WeightedMean(_relativeFrequencies);
        }

        private double WhenTheMeanIsCalculated()
        {
            return Math.Round(_dataSet.Mean(),5);
        }
    }
}
