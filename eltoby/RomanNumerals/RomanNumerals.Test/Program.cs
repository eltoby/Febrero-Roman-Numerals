using System;
using System.Collections.Generic;
using System.Text;
using RomanNumerals.Logic;
namespace RomanNumerals.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testInputs = {1,10,7,999,1990,2008,1427,1999};

            List<string> outputs = new List<string>();
            Converter conv = new Converter();
            foreach (int number in testInputs)
            {
                Console.WriteLine(string.Format("Test: {0}", number));
                string output = conv.ConvertToRoman(number);
                Console.WriteLine(string.Format("Result: {0}", output ));
                outputs.Add(output);
                Console.WriteLine("------------");
            }

            foreach (string roman in outputs)
            {
                Console.WriteLine(string.Format("Test: {0}", roman));
                Console.WriteLine(string.Format("Result: {0}", conv.ConvertToNumber(roman)));
                Console.WriteLine("------------");
            }
            Console.WriteLine("Test Ended. Press Enter to continue...");
            Console.Read();

        }
    }
}
