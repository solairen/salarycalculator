using System;
using System.Threading;
using CommandLine;

namespace SalaryCalculator{
    class Program{

        public class Options{
            [Option('h', "hours", Required = true, HelpText = "Enter worked hours.")]
            public decimal _hours { get; set; }

            [Option('w', "hourly-wage", Required = true, HelpText = "Enter hourly wage.")]
            public decimal _wage { get; set; }
        }

        static void Main(string[] args){
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(o => {
                Console.WriteLine($"Worked hours: {Math.Abs(o._hours)}");
                Console.WriteLine($"Hourly rate: {Math.Abs(o._wage)}");
                Console.WriteLine($"Payment: {Math.Round(Math.Abs(o._hours * o._wage))}");
            });
        }
    }
}