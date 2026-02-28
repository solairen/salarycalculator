using System.Globalization;
using CommandLine;

namespace SalaryCalculator.Common
{
    public class OptionsHelper
    {
        [Option('h', "hours", Required = true, HelpText = "Enter worked hours.")]
        public string RawHours { get; set; } = string.Empty;

        [Option('w', "hourly-wage", Required = true, HelpText = "Enter hourly wage.")]
        public string RawHourlyWage { get; set; } = string.Empty;

        public decimal Hours => decimal.Parse(RawHours.Replace(',', '.'), CultureInfo.InvariantCulture);

        public decimal HourlyWage => decimal.Parse(RawHourlyWage.Replace(',', '.'), CultureInfo.InvariantCulture);
    }
}
