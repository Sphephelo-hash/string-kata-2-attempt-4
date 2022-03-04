using System.Collections.Generic;

namespace StringCalculatorTwo.Services
{
    public interface IProcessNumbers
    {
        void CheckForNumbersAboveRange(List<int> numbers);
        List<int> ConvertAndCheckNumbersAboverange(string numbers);
        int ConvertCharToInt(char letter);
        List<int> ConvertStringNumbersToInt(string[] numbers);
    }
}