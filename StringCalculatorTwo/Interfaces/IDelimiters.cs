namespace StringCalculatorTwo.Services
{
    public interface IDelimiters
    {
        string[] FindDelimiters(string delimitersAndSeparators, char[] separators);
        char[] FindSeparators(string numbers);
        string[] GetDelimiters(string numbers);
    }
}