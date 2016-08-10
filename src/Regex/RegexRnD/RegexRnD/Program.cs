using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexRnD
{
    class Program
    {
        private static SubstringMatch substringMatchEngine;
        public static void Init()
        {
            substringMatchEngine = new SubstringMatch();
        }
        static void Main(string[] args)
        {
            Init();
            Regex r = new Regex(@"(\?office)w+");
            MatchCollection words = r.Matches("The office is closed, please visit our blog");

            foreach (Match word in words)
            {
                string legalWord = word.Groups[0].Value;
            }
            Test1();

            int u = 0;
        }

        private static void Test1()
        {
            //string value = "33 333 33333 33333333";// output only 2 digit numbers
            string value = "55555";// output only 2 digit numbers
            string regex = @"([0-9]+)([a-z]+)([A-Z]+)";
            var myMatches = substringMatchEngine.GetMatchResult(value, regex);
            var myvalidation = substringMatchEngine.GetValidationResult(value, regex);
            myvalidation = substringMatchEngine.GetValidationResult("aA1", regex);
            myvalidation = substringMatchEngine.GetValidationResult("aA.", regex);
            myvalidation = substringMatchEngine.GetValidationResult("a.1", regex);
            myvalidation = substringMatchEngine.GetValidationResult(".A1", regex);
            myvalidation = substringMatchEngine.GetValidationResult("aaaaaa", regex);
            myvalidation = substringMatchEngine.GetValidationResult("aaaaaa1", regex);
            myvalidation = substringMatchEngine.GetValidationResult("aaaaaa1A", regex);
        }
    }
}
/*
 Problems to solve :
 * Find all 2 and 3 digit numbers from the following string 
 * 55 AND 4 OR 5656 BUT 57.*?98.99AND100.101.102+103|104&105<106>107=108/109%110 1111 111 11 1
 * Answer : 55,57,98,99,100,101,102,103,104,105,106,107,108,109,110,111
 */
/*
 Lowercase = Count
 * Uppercase = Count
 * Digit = count
 * Special Character
 */