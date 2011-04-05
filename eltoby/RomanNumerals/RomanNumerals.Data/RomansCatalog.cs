using System;
using System.Collections.Generic;
using System.Text;
using RomanNumerals.Objects;
namespace RomanNumerals.Data
{
    public class RomansCatalog
    {
        static RomansCatalog instance;
        List<Roman> romans;
        private RomansCatalog()
        {
            romans = new List<Roman>();
            romans.Add(new Roman("I", 1, true));
            romans.Add(new Roman("V", 5, false));
            romans.Add(new Roman("X", 10, true));
            romans.Add(new Roman("L", 50, false));
            romans.Add(new Roman("C", 100, true));
            romans.Add(new Roman("D", 500, false));
            romans.Add(new Roman("M", 1000, true));            
        }

        public static RomansCatalog GetInstance()
        {
            if (instance == null)
                instance = new RomansCatalog();
            return instance;
        }

        public Roman[] GetAll()
        {
            return romans.ToArray();
        }

        public Roman Higher(Roman number)
        {
            bool isNext = false;
            foreach (Roman r in romans)
                if (isNext)
                    return r;
                else
                    if (r == number)
                        isNext = true;

            return null;
        }
        public Roman Lower(Roman number)
        {
            Roman previous = null;
            foreach (Roman r in romans)
                if (r == number)
                    return previous;
                else
                    previous = r;

            return null;
        }

        public Roman GetOne(char letter)
        {
            foreach (Roman r in romans)
                if (r.Letter == letter.ToString())
                    return r;
            return null;
        }
    }
}
