using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace D1.Input
{
    public class SpelledDigitReplacer
    {

        private readonly Dictionary<string, string> _digits = new Dictionary<string, string>()
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3e" },
            { "four", "f4r" },
            { "five", "f5e" },
            { "six", "s6x" },
            { "seven", "s7n" },
            { "eight", "e8t" },
            { "nine", "n9e" },
        };
    
        public string[] GetResolvedInput(string[] inputLines)
        {
            return inputLines.Select(GetResolvedLine).ToArray();
        }

        private string GetResolvedLine(string inputLine)
        {
            var resolvedLine = new string(inputLine);
            return _digits.Aggregate(resolvedLine, (current, unused) => ResolveLine(current));
        }

        private string ResolveLine(string input)
        {
            var indexes = new Dictionary<int, string>();

            var output = new string(input);
            foreach (var digit in _digits)
            {
                var index = input.IndexOf(digit.Key, StringComparison.InvariantCultureIgnoreCase);
                if (index != -1)
                {
                    indexes.Add(index, digit.Key);
                }
            }
        
            var indexList = indexes.Keys.ToList();
            if (indexList.Count == 0)
            {
                return output;
            }
        
            var minValue = indexList.Min();
            var valueToResolve = indexes[minValue];
            var number = _digits[valueToResolve];
        
            var regex = new Regex(Regex.Escape(valueToResolve), RegexOptions.IgnoreCase);
            output = regex.Replace(output, number, 1);
        
            return output;
        }
    }
}