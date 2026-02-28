using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalaryCalculator.Tests
{
    [TestClass]
    public class SalaryCalculatorTests
    {
        private static readonly CultureInfo CommaCulture = new("pl-PL");

        private static decimal ParseDecimalInvariant(string value)
        {
            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }

        [TestMethod]
        public void Test_Dot()
        {
            string hour = "68.56";
            string value = "77.68";

            decimal enteredHours = ParseDecimalInvariant(hour);
            decimal paymentValue = ParseDecimalInvariant(value);
            decimal sum = Math.Round(Math.Abs(enteredHours * paymentValue));

            Assert.AreEqual(5326m, sum);
        }

        [TestMethod]
        public void Test_Comma()
        {
            string hour = "29,10";
            string value = "10,20";

            decimal enteredHours = decimal.Parse(hour, CommaCulture);
            decimal paymentValue = decimal.Parse(value, CommaCulture);
            decimal sum = Math.Round(Math.Abs(enteredHours * paymentValue));

            Assert.AreEqual(297m, sum);
        }

        [TestMethod]
        public void Test_Comma_Dot()
        {
            string hour = "777,10";
            string value = "10.991";

            decimal enteredHours = decimal.Parse(hour, CommaCulture);
            decimal paymentValue = ParseDecimalInvariant(value);
            decimal sum = Math.Round(Math.Abs(enteredHours * paymentValue));

            Assert.AreEqual(8541m, sum);
        }

        [TestMethod]
        public void Test_Dot_Comma()
        {
            string hour = "777.10";
            string value = "10,991";

            decimal enteredHours = ParseDecimalInvariant(hour);
            decimal paymentValue = decimal.Parse(value, CommaCulture);
            decimal sum = Math.Round(Math.Abs(enteredHours * paymentValue));

            Assert.AreEqual(8541m, sum);
        }
    }
}
