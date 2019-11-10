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
        IList<double> _intervals;
        private Dictionary<double, double> _absoluteFrequencies, _relativeFrequencies;

        [TestCase("1,3,5", "0.0,4.0,10.0", "2,1")]
        [TestCase("-1,0,1,3,5", "-2.0,4.0,10.0", "4,1")]
        [TestCase("-1,0,1,3,5", "0.0,5.5", "4")]
        [TestCase("-1,0,1,3,5", "-1.0,3", "3")]
        [TestCase("1,3,5", "0.0,0.5", "0")]
        public void GetAbsoluteFrequencies(string data, string intervals, string expected)
        {
            _dataSet = GivenASetOfData(data);
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
            _dataSet = GivenASetOfData(data);
            _intervals = GivenASetOfData(intervals);
            _expectedValues = GivenASetOfData(expected);

            _relativeFrequencies = WhenGetRelativeFrequenciesIsCalculated(roundTo);

            Assert.AreEqual(_relativeFrequencies.Values.ToList(), _expectedValues);
        }

        private Dictionary<double, double> WhenGetRelativeFrequenciesIsCalculated(int roundTo)
        {
            return _dataSet.GetRelativeFrequenciesForIntervals(_intervals, roundTo);
        }

        private Dictionary<double,double> WhenAbsoluteFrequenciesIsCalculated()
        {
             return _dataSet.GetAbsoluteFrequenciesForIntervals(_intervals);
        }

    }
}
