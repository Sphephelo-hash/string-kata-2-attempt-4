using System.Collections.Generic;

namespace StringCalculatorTwo.Services
{
    public class ProcessNumbers : IProcessNumbers
    {

        IExceptions _exceptions;
        public ProcessNumbers(IExceptions exceptions)
        {
            _exceptions = exceptions;
        }

        public List<int> ConvertAndCheckNumbersAboverange(string[] stringNumbers)
        {
            List<int> numbers = ConvertStringNumbersToInt(stringNumbers);
            CheckForNumbersAboveRange(numbers);

            return numbers;
        }

        public List<int> ConvertStringNumbersToInt(string[] numbers)
        {
            List<int> intNumbers = new List<int>();
            foreach (string number in numbers)
            {
                if (char.IsLetter(number[0]))
                {
                    intNumbers.Add(ConvertCharToInt(number[0]));
                }
                else
                {
                    intNumbers.Add(int.Parse(number));
                }
            }

            return intNumbers;
        }

        public int ConvertCharToInt(char letter)
        {
            int result = letter % 32 - 1;
            return (result < 10 && result > 0) ? result : 0;
        }

        public void CheckForNumbersAboveRange(List<int> numbers)
        {
            string numbersAboveRange = string.Empty;

            foreach (int number in numbers)
            {
                if (number > Constants.UpperBound)
                {
                    numbersAboveRange += number + " ";
                }
            }

            if (!string.IsNullOrEmpty(numbersAboveRange))
            {
                _exceptions.NumbersAboveRangeException(numbersAboveRange);

            }
        }
    }
}
