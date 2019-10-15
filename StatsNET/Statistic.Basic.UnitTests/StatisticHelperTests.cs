﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Statistic.Basic.UnitTests
{
    [TestFixture]
    public class StatisticHelperTests
    {
        IList<double> _dataSet;
        double _startInterval, _endInterval;
        double _result;

        [OneTimeSetUp]

        //28, 35, 42, 90, 70, 56, 75, 66, 30, 89, 75, 64, 81, 69, 55, 83, 72, 68, 73, 16
        [TestCase("1,3,5",0,3,2)]
        public void GetAbsoluteFrequencyShouldReturnTheCorrectFrequencyForASpecificInterval(string data, double startInterval, double endInterval, int expected)
        {
            GivenASetOfData(data);
            GivenASpecificRange(startInterval, endInterval);
            WhenGetAbsoluteFrequencyIsCalled();
            ThenItShouldReturnTheCorrectAbsoluteFrequency(expected);
        }

        private void ThenItShouldReturnTheCorrectAbsoluteFrequency(double expected)
        {
            _result.ShouldEqual(expected);
        }

        private void WhenGetAbsoluteFrequencyIsCalled()
        {
            _result = _dataSet.GetAbsoluteFrequencyInRange(_startInterval, _endInterval);
        }

        private void GivenASpecificRange(double startInterval, double endInterval)
        {
            _startInterval = startInterval;
            _endInterval = endInterval;
        }

        private void GivenASetOfData(string data)
        {
            _dataSet = data.Split(',').Select(double.Parse).ToList();
        }


    }
}