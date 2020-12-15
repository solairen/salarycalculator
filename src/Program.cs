using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace SalaryCalculator{
    class Program{
        private static string _name = Assembly.GetExecutingAssembly().GetName().Name;
        private static decimal _enterHours, _paymentValue;
        private static bool _ostype;
        private static string docker = "/.dockerenv";
        static void Main(string[] args){
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            _ostype = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            try{
                if(args.Length == 0){
                    if(_ostype == true){
                        try{
                            Console.WriteLine("Enter hours:");
                            _enterHours = Convert.ToDecimal(Console.ReadLine().Replace(',','.'));
                            Console.WriteLine("Enter salary wage");
                            _paymentValue = Convert.ToDecimal(Console.ReadLine().Replace(',','.'));
                            Console.Clear();
                            Console.WriteLine("Worked hours: {0}", Math.Abs(_enterHours));
                            Console.WriteLine("Hourly rate: {0}", Math.Abs(_paymentValue));
                            Console.WriteLine("Payment: {0}", Math.Round(Math.Abs(_enterHours * _paymentValue)));
                            Console.WriteLine("Press enter to exit...");
                            Console.ReadKey();
                        }
                        catch(Exception){
                            Console.WriteLine("hours or hourlyrate are not numbers!");
                        }
                    }
                    else{
                        if(File.Exists(docker)){
                            Console.WriteLine("Usage: docker run -ti moleszek/{0}:1.2 -h/hours 100 -hw/hourlywage 10", _name.ToLower());
                        }
                        else{
                            Console.WriteLine("Usage: dotnet moleszek/{0}.dll -h/hours 100 -hw/hourlywage 10", _name.ToLower());
                        }
                    }
                }
                else if((args[0].Contains("-hours") || args[0].Contains("-h")) && (args[2].Contains("-hourlywage") || args[2].Contains("-hw"))){
                    try{
                        _enterHours = Convert.ToDecimal(args[1].Replace(",", "."));
                        _paymentValue = Convert.ToDecimal(args[3].Replace(",", "."));
                        Console.WriteLine("Worked hours: {0}", Math.Abs(_enterHours));
                        Console.WriteLine("Hourly rate: {0}", Math.Abs(_paymentValue));
                        Console.WriteLine("Payment: {0}", Math.Round(Math.Abs(_enterHours * _paymentValue)));
                    }
                    catch(Exception){
                        Console.WriteLine("hours or hourlyrate are not numbers!");
                    }
                }
            }
            catch(Exception){
                if(_ostype == true){
                    Console.WriteLine("Usage: {0}.exe -h/hours 100 -hw/hourlywage 10", _name);
                }
                if(_ostype){
                    if(File.Exists(docker)){
                        Console.WriteLine("Usage: docker run -ti moleszek/{0}:1.2 -h/hours 100 -hw/hourlywage 10", _name.ToLower());
                    }
                    else{
                        Console.WriteLine("Usage: dotnet moleszek/{0}.dll -h/hours 100 -hw/hourlywage 10", _name.ToLower());
                    }
                }
            }
        }
    }
}