using System.Collections.Generic;
using System.Linq;

namespace Statistic.Basic.Tests
{
    public class BaseTestClass
    {
        protected IList<double> _dataSet, _intervals;
        
        protected void GivenASeriesOfValuesAsIntervals(string intervals)
        {
            _intervals = ParseStringToListOfDouble(intervals);
        }

        protected void GivenASetOfData(string data)
        {
            _dataSet = ParseStringToListOfDouble(data);
        }

        protected List<double> ParseStringToListOfDouble(string dataAsString)
        {
            return dataAsString.Split(',').Select(double.Parse).ToList();
        }
    }
}