using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CaseInvariantKmp
{
    class Program
    {
        private const int MaxLen = 100;
        private static char[] Pattern = new char[MaxLen];
        private static char[] Text = new char[MaxLen];
        private static int[] Border = new int[MaxLen];
        private static int PatternLength;
        private static int TextLength;


        static char toLower(char a)
        {
            if(a>='A' && a<='Z')return (char) ((char)'a'+(a-'A'));
            return a;
        }
        static bool Equals(char a,char b)
        {
            return a == b;
            return toLower(a) == toLower(b);
        }
        static List<int> KmpSearch()
        {
            List<int> result = new List<int>();
            int i = 0, j = 0;
            while (i < TextLength)
            {
                //while (j >= 0 && Equals(Text[i], Pattern[j])) j = Border[j]; 
                while (j >= 0 && Text[i]!=Pattern[j]) j = Border[j]; 
                i++; j++;
                if (j == PatternLength)
                {
                    result.Add(i-j);
                    j = Border[j];
                }
            }
            return result;
        }

        static void KmpPreprocess()
        {
            int i = 0, j = -1;
            Border[i] = j;
            while (i < PatternLength)
            {
                //while (j >= 0 && !Equals(Pattern[i] , Pattern[j])) j = Border[j];
                while (j >= 0 && Pattern[i]!=Pattern[j]) j = Border[j];
                i++; j++;
                Border[i] = j;
            }
        }

        static void Main(string[] args)
        {
            Text = Console.ReadLine().ToCharArray();
            TextLength = Text.Length;
            Pattern = Console.ReadLine().ToCharArray();
            PatternLength = Pattern.Length;
            KmpPreprocess();
            List<int> occurences = KmpSearch();
        }
    }
}
/*
abcabcab
ca
 */