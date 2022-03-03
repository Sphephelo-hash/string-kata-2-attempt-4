using StringCalculatorTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTwo
{
    public class StringCalculator
    {
        ICalculator _calculator;
        IDelimiters _delimiters;   
        IProcessNumbers _processNumbers;
        ISplit _split;

        public StringCalculator(IDelimiters delimiters, ISplit split, IProcessNumbers processNumbers, ICalculator calculator)
        {
            _delimiters = delimiters;
            _split = split;
            _processNumbers = processNumbers;
            _calculator = calculator;
        }

        public int Subtract(string numbers)
        {
            numbers = numbers.Replace("-", "");
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            string[] delimiters = _delimiters.GetDelimiters(numbers);
            int startingIndex = char.IsLetterOrDigit(numbers[0]) ?  0: numbers.IndexOf(Constants.NewLine);
            string[] stringNumbers = _split.SplitNumbers(numbers, delimiters, startingIndex);
            int[] intNumbers = _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers);
            return _calculator.CalculateNumbers(intNumbers);
        }
    }
}
