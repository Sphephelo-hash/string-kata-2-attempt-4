namespace StringCalculatorTwo.Services
{
    public interface ISplit
    {
        string[] SplitNumbers(string numbers, string[] delimiters, int startingIndex);
    }
}