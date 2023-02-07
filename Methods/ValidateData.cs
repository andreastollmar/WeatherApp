using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherApp.Methods
{
    internal class ValidateData
    {
        public static void ValidateDate(string promt)
        {
            Console.WriteLine(promt);
            var input = Console.ReadLine();
            while (!IsValidDate(input))
            {
                Console.WriteLine("Invalid input, try again: ");
                input = Console.ReadLine();
            }
            // Kör nästa method som letar upp alla matches med datumet inläst från användare

        }

        private static bool IsValidDate(string input)
        {
            string pattern = @"2016-(0?[0-9]|1?[1-2])-(0-2[0-9]|3[0-1])";
            return Regex.IsMatch(input, pattern);

        }
    }
}
