using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Statistic.Basic.Tests
{
    public class BaseTestClassHelper
    {
        protected IList<double> _dataSet, _expectedValues;
        private const double _threshold = 0.001;
        
        protected IList<double> GivenASetOfData(string data)
        {
            return ParseStringToListOfDouble(data);
        }

        protected List<double> ParseStringToListOfDouble(string dataAsString)
        {
            return dataAsString.Split(',').Select(double.Parse).ToList();
        }

        protected void ThenItShouldReturnTheExpectedValue(double actual, double expected)
        {
            Assert.IsTrue(ValuesAreComparable(actual,expected));
        }



        protected void ThenItShouldReturnTheExpectedValues(IList<double> actual, IList<double> expected)
        {
            //Assert.AreEqual(expected, actual);
            Assert.IsTrue(ValuesAreComparable(actual, expected));
        }

        private bool? ValuesAreComparable(double actual, double expected)
        {
            double difference = actual - expected;
            return IsInThreshold(difference);
        }

        private bool? ValuesAreComparable(IList<double> actual, IList<double> expected)
        {
            if (actual.Count != expected.Count) return false;

            for (int i = 0; i < actual.Count; i++)
            {
                double difference = actual[i] - expected[i];

                if (!IsInThreshold(difference)) return false;
            }

            return true;
        }

        private bool IsInThreshold (double value)
        {
            return value < _threshold;
        }
    }
}