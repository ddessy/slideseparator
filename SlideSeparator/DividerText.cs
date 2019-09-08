using System;
using System.Collections.Generic;
using System.Text;

namespace SlideSeparator
{
    public class DividerText
    {
        public string Remainder { get; }
        public string Quotient { get; }

        private string targetString;
        private int numberSymbols;

        public DividerText(string givenString, int numberSymbols)
        {
            if (givenString.Length < numberSymbols)
            {
                numberSymbols = givenString.Length;
                Quotient = givenString;
                Remainder = string.Empty;
            }
            else
            {
                string targetString = givenString.Substring(0, numberSymbols);
                bool endCorrect = targetString.EndsWith('\n') || targetString.EndsWith('.') || targetString.EndsWith(',') || targetString.EndsWith('-') || targetString.EndsWith(';') || Char.IsWhiteSpace(targetString[numberSymbols - 1]);
                if (endCorrect)
                {
                    Quotient = targetString;
                    Remainder = givenString.Substring(numberSymbols).TrimStart();
                }
                else
                {
                    int lastWhitespaceIndex = targetString.LastIndexOf(" ");
                    Quotient = givenString.Substring(0, lastWhitespaceIndex);
                    Remainder = givenString.Substring(lastWhitespaceIndex).TrimStart();
                } 
            }
        }
    }
}
