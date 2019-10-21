using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Statistic.Basic.Tests
{
    [TestFixture]
    class MeasureOfCentralTendecyCalculatorTests : BaseTestClass
    {
        private double _mean, _weightedMean, _median;
        private IList<double> _relativeFrequencies;

        [TestCase("22,24,21,30,28,29", 25.66667)]
        [TestCase("1,1,1,1",1)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26",24.4)]
        public void ArithmeticMeanShouldReturnTheCorrectValue(string data, double expected)
        {
            GivenASetOfData(data);
            WhenMeanIsCalled();
            ThenItShouldReturnTheExpectedValue(_mean,expected);
        }

        [TestCase("22,24,21,30,28,29")]
        [TestCase("1,1,1,1")]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26")]
        public void ArithmeticMeanProperties(string data)
        {
            GivenASetOfData(data);
            WhenMeanIsCalled();
            ThenTheSumOfTheDeviationOfEachVariableShoulbBeZero();
        }

        [TestCase("22.5,27.5,32.5","0.37, 0.58, 0.05",25.9)]
        public void WeightedMeanShouldReturnTheCorrectValue(string data, string relativeFrequencies, double expected)
        {
            GivenASetOfData(data);
            GivenTheRespectiveRelativeFrequecies(relativeFrequencies);
            WhenWeightedMeanIsCalled();
            ThenItShouldReturnTheExpectedValue(_weightedMean, expected);
        }

        [TestCase("22.5,27.5,32.5", "0.37")]
        public void WeightedMeanShouldReturnAnExceptionWhenDataIsIncorrect(string data, string relativeFrequencies)
        {
            GivenASetOfData(data);
            GivenTheRespectiveRelativeFrequecies(relativeFrequencies);
            ThenAnExceptionShouldBeThrown();
        }

        [TestCase("22.46,24.1,21.78,30.954", 23.28)]
        [TestCase("22,24,21,30,28", 24)]
        [TestCase("22,24,21,30,28,29",26)]
        [TestCase("22,21.18,15.98,24,21,30,28,29,29,29,29", 28)]
        [TestCase("-22,-24.67,-21.9,30.21,28,29",3.05)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26",25)]
        public void TheMedianShouldReturnTheCorrectValue(string data, double exptected)
        {
            GivenASetOfData(data);
            WhenMedianIsCalled();
            ThenItShouldReturnTheExpectedValue(_median, exptected);
        }

        private void WhenMedianIsCalled()
        {
            _median = Math.Round(_dataSet.Median(),5);
        }

        private void ThenTheSumOfTheDeviationOfEachVariableShoulbBeZero()
        {
            double deviationsSum = 0;
            foreach (var data in _dataSet)
            {
                deviationsSum += (data - _mean);
            }

            Assert.AreEqual(0, Math.Round(deviationsSum, 4));
        }

        private void ThenAnExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentException>(() => WhenWeightedMeanIsCalled());
        }

        private void WhenWeightedMeanIsCalled()
        {
            _weightedMean = _dataSet.WeightedMean(_relativeFrequencies);
        }

        private void GivenTheRespectiveRelativeFrequecies(string relativeFrequencies)
        {
            _relativeFrequencies = ParseStringToListOfDouble(relativeFrequencies);
        }

        private void ThenItShouldReturnTheExpectedValue(double actual, double expected)
        {
            Assert.AreEqual(expected, actual);
        }

        private void WhenMeanIsCalled()
        {
            _mean = Math.Round(_dataSet.Mean(),5);
        }


    }
}
