using System;

namespace StringCalculatorTwo.Services
{
    public class Split : ISplit
    {
        public string[] SplitNumbers(string numbers, string[] delimiters, int startingIndex)
        {
            if (startingIndex != 0)
            {
                string trimmedNumbers = numbers.Substring(startingIndex + 1);

                return trimmedNumbers.Split(delimiters, StringSplitOptions.None);
            }

            return numbers.Split(delimiters, StringSplitOptions.None); ;
        }
    }
}
