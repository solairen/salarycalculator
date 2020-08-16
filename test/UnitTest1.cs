using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        private static decimal _enterHours, _paymentValue, _sum;
        private static string _hour, _value;

        [TestMethod]
        public void Test_dot(){
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            _hour = "68.56";
            _value = "77.68";
            _enterHours = Convert.ToDecimal(_hour);
            _paymentValue = Convert.ToDecimal(_value);
            _sum = Math.Round(Math.Abs(_enterHours * _paymentValue));
            Assert.AreEqual(5326, _sum);
        }

        [TestMethod]
        public void Test_comma(){
            _hour = "29,10";
            _value = "10,20";
            _enterHours = Convert.ToDecimal(_hour.Replace(',','.'));
            _paymentValue = Convert.ToDecimal(_value.Replace(',','.'));
            _sum = Math.Round(Math.Abs(_enterHours * _paymentValue));
            Assert.AreEqual(297, _sum);
        }

        [TestMethod]
        public void Test_comma_dot(){
            _hour = "777,10";
            _value = "10.991";
            _enterHours = Convert.ToDecimal(_hour.Replace(',','.'));
            _paymentValue = Convert.ToDecimal(_value);
            _sum = Math.Round(Math.Abs(_enterHours * _paymentValue));
            Assert.AreEqual(8541, _sum);
        }

        [TestMethod]
        public void Test_dot_comma(){
            _hour = "777.10";
            _value = "10,991";
            _enterHours = Convert.ToDecimal(_hour);
            _paymentValue = Convert.ToDecimal(_value.Replace(',','.'));
            _sum = Math.Round(Math.Abs(_enterHours * _paymentValue));
            Assert.AreEqual(8541, _sum);
        }
    }
}