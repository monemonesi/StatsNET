using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Statistic.Basic.Tests
{
    [TestFixture]
    class MeasureOfCentralTendecyCalculatorTests : BaseTestClass
    {
        private double _mean;

        [TestCase("22,24,21,30,28,29", 25.66667)]
        [TestCase("1,1,1,1",1)]
        [TestCase("22,24,21,22,25,26,25,24,23,25,25,26,27,25,26",24.4)]
        public void ArithmeticMeanShouldReturnTheCorrectValue(string data, double expected)
        {
            GivenASetOfData(data);
            WhenMeanIsCalled();
            ThenItShouldReturnTheCorrectArithmeticMean(expected);
        }

        private void ThenItShouldReturnTheCorrectArithmeticMean(double expected)
        {
            Assert.AreEqual(expected, _mean);
        }

        private void WhenMeanIsCalled()
        {
            _mean = Math.Round(_dataSet.Mean(),5);
        }


    }
}
