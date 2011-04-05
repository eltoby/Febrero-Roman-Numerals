using System;
using System.Collections.Generic;
using System.Text;
using RomanNumerals.Objects;
namespace RomanNumerals.Data
{
    public class ReplacementPatternCatalog
    {
        static ReplacementPatternCatalog instance;
        List<ReplacementPattern> patterns;
        private ReplacementPatternCatalog()
        {
            patterns = new List<ReplacementPattern>();

            RomansCatalog romCatalog =RomansCatalog.GetInstance();
            foreach (Roman r in romCatalog.GetAll())
            {
                Roman higher = romCatalog.Higher(r);
                if (r.Repeatable)
                {                   
                    if (higher == null)
                        continue;

                    StringBuilder patternBuilder = new StringBuilder();
                    patternBuilder.Append(r.Letter[0], 4);
                    patterns.Add(new ReplacementPattern(patternBuilder.ToString(), string.Concat(r.Letter, higher.Letter)));
                }
                else
                {
                    Roman lower = romCatalog.Lower(r);
                    if (lower == null)
                        continue;

                    StringBuilder patternBuilder = new StringBuilder();
                    patternBuilder.Append(r.Letter);
                    patternBuilder.Append(lower.Letter);
                    patternBuilder.Append(r.Letter);

                    StringBuilder replacementBuilder = new StringBuilder();
                    replacementBuilder.Append(lower.Letter);
                    replacementBuilder.Append(higher.Letter);
                    patterns.Add(new ReplacementPattern(patternBuilder.ToString(), replacementBuilder.ToString()));                   
                }
            }
        }

        public static ReplacementPatternCatalog GetInstance()
        {
            if (instance == null)
                instance = new ReplacementPatternCatalog();
            return instance;
        }

        public ReplacementPattern[] GetAll()
        {
            return patterns.ToArray();
        }

    }
}
