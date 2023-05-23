using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace TestProject
{
    [TestClass]
    public class SalaryCalculatorTests
    {
        private decimal _enteredHours, _paymentValue, _sum;
        private string _hour, _value;

        [TestMethod]
        public void Test_Dot()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            _hour = "68.56";
            _value = "77.68";
            _enteredHours = Convert.ToDecimal(_hour);
            _paymentValue = Convert.ToDecimal(_value);
            _sum = Math.Round(Math.Abs(_enteredHours * _paymentValue));
            Assert.AreEqual(5326, _sum);
        }

        [TestMethod]
        public void Test_Comma()
        {
            _hour = "29,10";
            _value = "10,20";
            _enteredHours = Convert.ToDecimal(_hour.Replace(',', '.'));
            _paymentValue = Convert.ToDecimal(_value.Replace(',', '.'));
            _sum = Math.Round(Math.Abs(_enteredHours * _paymentValue));
            Assert.AreEqual(297, _sum);
        }

        [TestMethod]
        public void Test_Comma_Dot()
        {
            _hour = "777,10";
            _value = "10.991";
            _enteredHours = Convert.ToDecimal(_hour.Replace(',', '.'));
            _paymentValue = Convert.ToDecimal(_value);
            _sum = Math.Round(Math.Abs(_enteredHours * _paymentValue));
            Assert.AreEqual(8541, _sum);
        }

        [TestMethod]
        public void Test_Dot_Comma()
        {
            _hour = "777.10";
            _value = "10,991";
            _enteredHours = Convert.ToDecimal(_hour);
            _paymentValue = Convert.ToDecimal(_value.Replace(',', '.'));
            _sum = Math.Round(Math.Abs(_enteredHours * _paymentValue));
            Assert.AreEqual(8541, _sum);
        }
    }
}
