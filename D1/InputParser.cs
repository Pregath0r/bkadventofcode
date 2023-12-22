using System;
using System.Collections.Generic;
using System.Linq;

namespace D1
{
    public class InputParser
    {
        public IEnumerable<int> GetCalibrationValues(string[] inputLines)
        {
            return inputLines.Select(GetCalibrationValue);
        }
    
        private int GetCalibrationValue(string inputLine)
        {
            var firstDigit = GetFirstDigit(inputLine);
            var lastDigit = GetLastDigit(inputLine);
            var mergedDigits = MergeDigits(firstDigit, lastDigit);

            return mergedDigits;
        }

        private string GetFirstDigit(string inputLine)
        {
            foreach (var character in inputLine.Where(char.IsDigit))
            {
                return character.ToString();
            }

            throw new ArgumentException("No digit found in input line");
        }
    
        private string GetLastDigit(string inputLine)
        {
            var digitList = (from character in inputLine where char.IsDigit(character) select character.ToString()).ToList();
            return digitList[^1];
        }
    
        private int MergeDigits(string firstDigit, string lastDigit)
        {
            var mergedText = $"{firstDigit}{lastDigit}";
            return int.Parse(mergedText);
        }
    }
}