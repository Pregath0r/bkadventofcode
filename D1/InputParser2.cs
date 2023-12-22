using System.Collections.Generic;
using System.Linq;

namespace D1
{
    public class InputParser2
    {
        public IEnumerable<long> GetCalibrationValues(string[] inputLines)
        {
            return inputLines.Select(GetCalibrationValue);
        }
    
        private long GetCalibrationValue(string inputLine)
        {
            int firstDigit = 1;
            foreach (var character in inputLine.Where(char.IsDigit))
            {
                firstDigit = int.Parse(character.ToString());
                break;
            }
            var digitList = (from character in inputLine where char.IsDigit(character) select character).ToList();
            var lastDigit = int.Parse(digitList[^1].ToString());
            return Concat(firstDigit, lastDigit);
        }

        private static long Concat(int a, int b)
        {
            if (b < 10) return 10L * a + b;
            if (b < 100) return 100L * a + b;
            if (b < 1000) return 1000L * a + b;
            if (b < 10000) return 10000L * a + b;
            if (b < 100000) return 100000L * a + b;
            if (b < 1000000) return 1000000L * a + b;
            if (b < 10000000) return 10000000L * a + b;
            if (b < 100000000) return 100000000L * a + b;
            return 1000000000L * a + b;
        }
    }
}

