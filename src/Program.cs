using System;
using System.Threading;
using CommandLine;

namespace SalaryCalculator
{
    class Program
    {
        public class Options
        {
            [Option('h', "hours", Required = true, HelpText = "Enter worked hours.")]
            public decimal Hours { get; set; }

            [Option('w', "hourly-wage", Required = true, HelpText = "Enter hourly wage.")]
            public decimal HourlyWage { get; set; }
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(options =>
            {
                decimal workedHours = Math.Abs(options.Hours);
                decimal hourlyWage = Math.Abs(options.HourlyWage);
                decimal payment = Math.Round(workedHours * hourlyWage);

                Console.WriteLine($"Worked hours: {workedHours}");
                Console.WriteLine($"Hourly rate: {hourlyWage}");
                Console.WriteLine($"Payment: {payment}");
            });
        }
    }
}
