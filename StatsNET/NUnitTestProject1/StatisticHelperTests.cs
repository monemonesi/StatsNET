using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Statistic.Basic.UnitTests
{
    [TestFixture]
    public class StatisticHelperTests
    {
        IList<double> _dataSet, _intervals;
        double _startInterval, _endInterval;
        int _absoluteFrequency;
        List<int> _absoluteFrequencies;

        //28, 35, 42, 90, 70, 56, 75, 66, 30, 89, 75, 64, 81, 69, 55, 83, 72, 68, 73, 16
        [TestCase("1,3,5", 0.0, 3.0, 1)]
        [TestCase("1,3,5", 0.0, 0.5, 0)]
        [TestCase("1,3,5", 0.0, 5.5, 3)]
        [TestCase("-1,0,1,3,5", 0.0, 5.5, 4)]
        [TestCase("-1,0,1,3,5", -1.0, 3, 3)]
        public void GetAbsoluteFrequency(string data, double startInterval, double endInterval, int expected)
        {
            GivenASetOfData(data);
            GivenASpecificRange(startInterval, endInterval);
            WhenGetAbsoluteFrequencyIsCalled();
            ThenItShouldReturnTheCorrectAbsoluteFrequency(expected);
        }

        [TestCase("1,3,5", "0.0,4.0,10.0", "2,1")]
        public void GetAbsoluteFrequencies(string data, string intervals, string expected)
        {
            GivenASetOfData(data);
            GivenASeriesOfValuesAsIntervals(intervals);
            WhenGetAbsoluteFrequenciesIsCalled();
            ThenItShouldReturnTheCorrectFrequencyForEachInterval(expected);
        }

        private void WhenGetAbsoluteFrequenciesIsCalled()
        {
            _absoluteFrequencies = _dataSet.GetAbsoluteFrequenciesForIntervals(_intervals);
        }

        private void ThenItShouldReturnTheCorrectFrequencyForEachInterval(string expectedAsString)
        {
            List<int> expected = ParseStringToListOfInt(expectedAsString);
            Assert.AreEqual(expected, _absoluteFrequencies);
        }

  

        private void GivenASeriesOfValuesAsIntervals(string intervals)
        {
            _intervals = ParseStringToListOfDouble(intervals);
        }

        private void ThenItShouldReturnTheCorrectAbsoluteFrequency(int expected)
        {
            Assert.AreEqual(expected, _absoluteFrequency);
        }

        private void WhenGetAbsoluteFrequencyIsCalled()
        {
            _absoluteFrequency = _dataSet.GetAbsoluteFrequencyForInterval(_startInterval, _endInterval);
        }

        private void GivenASpecificRange(double startInterval, double endInterval)
        {
            _startInterval = startInterval;
            _endInterval = endInterval;
        }

        private void GivenASetOfData(string data)
        {
            _dataSet = ParseStringToListOfDouble( data);
        }

        private List<double> ParseStringToListOfDouble(string dataAsString)
        {
            return dataAsString.Split(',').Select(double.Parse).ToList();
        }

        private List<int> ParseStringToListOfInt(string dataAsString)
        {
            return dataAsString.Split(',').Select(int.Parse).ToList();
        }
    }
}
