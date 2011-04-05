using System;
using System.Collections.Generic;
using System.Text;
using RomanNumerals.Data;
using RomanNumerals.Objects;
namespace RomanNumerals.Logic
{
    public class Converter
    {

        public string ConvertToRoman(int number)
        {
            char[] partes = number.ToString().ToCharArray();
            Array.Reverse(partes);
            int potencia = 0;
            StringBuilder stbRoman = new StringBuilder();
            
            foreach(char c in partes) 
            {
                int part = int.Parse(c.ToString()) * (int)Math.Pow(10, potencia);
                if (part > 0)
                    stbRoman.Insert(0, getRomanDigit(part));
                potencia++;
            }
            return stbRoman.ToString();
        }

        string getRomanDigit(int number)
        {
            
            string preview = getRomanDigitPreview(number);
            foreach (ReplacementPattern r in ReplacementPatternCatalog.GetInstance().GetAll())
                preview = r.Replace(preview);

            return preview;
        }
        string getRomanDigitPreview(int number)
        {
            RomansCatalog catalog = RomansCatalog.GetInstance();
            Roman[] romans = catalog.GetAll();

            Roman previous = null;
            foreach (Roman n in romans)
                if (number == n)
                    return n.Letter;
                else
                    if (number > n)
                        previous = n;
                    else
                        break;

            return previous.Letter + getRomanDigitPreview(number - previous.Value);
                        
           
            
        }

        public int ConvertToNumber(string roman)
        {
            string start = "";
            string result = roman;
            while (start != result)
            {
                start = result;
                foreach (ReplacementPattern r in ReplacementPatternCatalog.GetInstance().GetAll())
                    result = r.ReverseReplace(result);
            }

            int number = 0;
            foreach (char c in result)
                number += RomansCatalog.GetInstance().GetOne(c).Value;

            return number;
        }
    }
}
