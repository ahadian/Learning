using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexRnD
{
    public class MatchResult
    {
        public int Index { get; set; }

        public string Text { get; set; }
    }
    public class SubstringMatch
    {
        public List<MatchResult> GetMatchResult(string text,string regex)
        {
            List<MatchResult> result = new List<MatchResult>();
            MatchCollection matches = Regex.Matches(text, regex);
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    result.Add(new MatchResult()
                    {
                        Index = capture.Index,
                        Text = capture.Value
                    });
                }
            }
            return result;
        }

        public bool GetValidationResult(string text, string regex)
        {
            return Regex.IsMatch(text, regex);
        }
    }
}
