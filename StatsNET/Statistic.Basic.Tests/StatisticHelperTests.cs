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
        Dictionary<double, int> _absoluteFrequencies;
        Dictionary<double, double> _relativeFrequencies;

        //28, 35, 42, 90, 70, 56, 75, 66, 30, 89, 75, 64, 81, 69, 55, 83, 72, 68, 73, 16
        [TestCase("1,3,5", "0.0,4.0,10.0", "2,1")]
        [TestCase("-1,0,1,3,5", "-2.0,4.0,10.0", "4,1")]
        [TestCase("-1,0,1,3,5", "0.0,5.5", "4")]
        [TestCase("-1,0,1,3,5", "-1.0,3", "3")]
        [TestCase("1,3,5", "0.0,0.5", "0")]
        public void GetAbsoluteFrequencies(string data, string intervals, string expected)
        {
            GivenASetOfData(data);
            GivenASeriesOfValuesAsIntervals(intervals);
            WhenGetAbsoluteFrequenciesIsCalled();
            ThenItShouldReturnTheCorrectAbsFrequencyForEachInterval(expected);
        }

        [TestCase("1,3,5", "0.0,4.0,10.0", "0.67,0.33")]
        public void GetRelativeFrequencies(string data, string intervals, string expected)
        {
            GivenASetOfData(data);
            GivenASeriesOfValuesAsIntervals(intervals);
            WhenGetRelativeFrequenciesIsCalled();
            ThenItShouldReturnTheCorrectRelativeFrequencyForEachInterval(expected);
        }

        private void ThenItShouldReturnTheCorrectRelativeFrequencyForEachInterval(string expectedAsString)
        {
            List<double> expected = ParseStringToListOfDouble(expectedAsString);
            List<double> results = _relativeFrequencies.Values.ToList();
            Assert.AreEqual(expected, results);
        }

        private void WhenGetRelativeFrequenciesIsCalled()
        {
            _relativeFrequencies = _dataSet.GetRelativeFrequenciesForIntervals(_intervals);
        }

        private void WhenGetAbsoluteFrequenciesIsCalled()
        {
            _absoluteFrequencies = _dataSet.GetAbsoluteFrequenciesForIntervals(_intervals);
        }

        private void ThenItShouldReturnTheCorrectAbsFrequencyForEachInterval(string expectedAsString)
        {
            List<int> expected = ParseStringToListOfInt(expectedAsString);
            List<int> results = _absoluteFrequencies.Values.ToList();
            Assert.AreEqual(expected, results);
        }

        private void GivenASeriesOfValuesAsIntervals(string intervals)
        {
            _intervals = ParseStringToListOfDouble(intervals);
        }

        private void GivenASetOfData(string data)
        {
            _dataSet = ParseStringToListOfDouble(data);
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
