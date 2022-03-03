namespace StringCalculatorTwo.Services
{
    public interface IProcessNumbers
    {
        void CheckForNumbersAboveRange(int[] numbers);
        int[] ConvertAndCheckNumbersAboverange(string[] stringNumbers);
        int ConvertCharToInt(char letter);
        int[] ConvertStringNumbersToInt(string[] numbers);
    }
}