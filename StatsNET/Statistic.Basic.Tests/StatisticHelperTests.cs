using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Statistic.Basic.Tests
{
    [TestFixture]
    public class StatisticHelperTests : BaseTestClassHelper
    {
        IList<double> _intervals, _rank;
        private Dictionary<double, double> _absoluteFrequencies, _relativeFrequencies;

        [TestCase("1,3,5", "0.0,4.0,10.0", "2,1")]
        [TestCase("-1,0,1,3,5", "-2.0,4.0,10.0", "4,1")]
        [TestCase("-1,0,1,3,5", "0.0,5.5", "4")]
        [TestCase("-1,0,1,3,5", "-1.0,3", "3")]
        [TestCase("1,3,5", "0.0,0.5", "0")]
        public void GetAbsoluteFrequencies(string data, string intervals, string expected)
        {
            _dataSet1 = GivenASetOfData(data);
            _intervals = GivenASetOfData(intervals);
            _expectedValues = GivenASetOfData(expected);

            _absoluteFrequencies = WhenAbsoluteFrequenciesIsCalculated();

            Assert.AreEqual(_absoluteFrequencies.Values.ToList(), _expectedValues);
        }

        [TestCase("1,3,5", "0.0,4.0,10.0", "0.67,0.33", 2)]
        [TestCase("-1,0,1,3,5", "-2.0,4.0,10.0", "0.800,0.200",3)]
        [TestCase("1,3,5", "0.0,4.0,10.0", "0.7,0.3", 1)]
        [TestCase("1,3,5", "0.0,0.5", "0", 5)]
        public void GetRelativeFrequencies(string data, string intervals, string expected, int roundTo)
        {
            _dataSet1 = GivenASetOfData(data);
            _intervals = GivenASetOfData(intervals);
            _expectedValues = GivenASetOfData(expected);

            _relativeFrequencies = WhenGetRelativeFrequenciesIsCalculated(roundTo);

            Assert.AreEqual(_relativeFrequencies.Values.ToList(), _expectedValues);
        }

        [TestCase("3,6,8,9", "1,2,3,4")]
        [TestCase("5,4,3,2,1", "5,4,3,2,1")]
        [TestCase("3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5", "4.5, 1.5, 6, 1.5, 8, 11, 3, 10, 8, 4.5")]
        [TestCase("3, 0.0, 4.5, 1.0, 5, 9, 2, 6, 5, 3, 5", "4.5, 1.0, 6.0, 2.0, 8.0, 11.0, 3.0, 10.0, 8.0, 4.5, 8.0")]
        public void GetRankShouldReturnTheCorrectValues(string data, string expected)
        {
            _dataSet1 = GivenASetOfData(data);
            _expectedValues = GivenASetOfData(expected);

            _rank = WhenTheRankIsCalculatedFor(_dataSet1);

            Assert.AreEqual(_expectedValues, _rank);

        }

        private IList<double> WhenTheRankIsCalculatedFor(IList<double> dataSet)
        {
            return dataSet.GetRank();
        }

        private Dictionary<double, double> WhenGetRelativeFrequenciesIsCalculated(int roundTo)
        {
            return _dataSet1.GetRelativeFrequenciesForIntervals(_intervals, roundTo);
        }

        private Dictionary<double,double> WhenAbsoluteFrequenciesIsCalculated()
        {
             return _dataSet1.GetAbsoluteFrequenciesForIntervals(_intervals);
        }

    }
}
