using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTwo.Services
{
    public class Delimiters : IDelimiters
    {
        public string[] GetDelimiters(string numbers)
        {
            if (numbers.StartsWith(Constants.OpeningFlag))
            {
                string delimitersAndSeparators = numbers.Substring(numbers.IndexOf(Constants.HashTag)+2, numbers.IndexOf(Constants.NewLine)-6);
                char[] separators = FindSeparators(numbers);
                return FindDelimiters(delimitersAndSeparators,separators );
            }

            if (numbers.StartsWith(Constants.CustomDelimiterFlag))
            {
                string customDelimiters = numbers.Substring(2, numbers.IndexOf(Constants.NewLine) - 2);
                if (numbers.StartsWith(Constants.CustomDelimiterFlag + Constants.OpeningSquareBracket))
                {
                    return FindDelimiters(customDelimiters, new char [] { Constants.OpeningSquareBracket, Constants.ClosingSquareBracket});
                }

                return new string[] { customDelimiters };
            }

            return new string[] { (Constants.NewLine.ToString()), (Constants.Comma.ToString()) };
        }

        public char[] FindSeparators(string numbers)
        {
            string[] splittedNumbers = numbers.Split(Constants.HashTag);
            string separatorsAndFlags = splittedNumbers[0];

            return new char[] { separatorsAndFlags[1], separatorsAndFlags[3] };
        }

        public string[] FindDelimiters(string delimitersAndSeparators, char[] separators)
        {
            delimitersAndSeparators = delimitersAndSeparators.Trim(separators);

            return delimitersAndSeparators.Split(new string[] { separators[1].ToString() + separators[0].ToString() }, StringSplitOptions.None);
        }
    }
}
