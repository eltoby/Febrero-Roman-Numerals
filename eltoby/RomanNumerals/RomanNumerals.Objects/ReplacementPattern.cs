using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumerals.Objects
{
    public class ReplacementPattern
    {
        string pattern;
        string replaceWith;

        public ReplacementPattern(string pattern, string replaceWith)
        {
            this.pattern = pattern;
            this.replaceWith = replaceWith;
        }

        public string Replace(string input)
        {
            return input.Replace(pattern, replaceWith);
        }

        public string ReverseReplace(string input)
        {
            return input.Replace(replaceWith, pattern);
        }
    }
}
