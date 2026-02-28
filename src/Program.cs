using System;
using CommandLine;
using SalaryCalculator.Common;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<OptionsHelper>(args).WithParsed<OptionsHelper>(options =>
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
