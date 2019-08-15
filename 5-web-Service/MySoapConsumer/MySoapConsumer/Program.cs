using MySoapConsumer.UnitConversionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoapConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number of Temp F.");
            if (int.TryParse(Console.ReadLine(), out var f))
            {
                double celcius;
                using (var client = new UnitConversionClient())
                {
                    try
                    {
                        celcius = client.FeetToMeeters(feet);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }

                Console.WriteLine($"Feet Conversion = {meters} meters");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
            Console.ReadKey();
        }
    }
}
