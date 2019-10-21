using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Statistic.Basic.Tests
{
    public class BaseTestClass
    {
        protected IList<double> _dataSet, _expectedValues;
        
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
            Assert.AreEqual(expected, actual);
        }

        protected void ThenItShouldReturnTheExpectedValues(IList<double> actual, IList<double> expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}