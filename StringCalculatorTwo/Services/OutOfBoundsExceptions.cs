using System;

namespace StringCalculatorTwo.Services
{
    public class OutOfBoundsExceptions : IExceptions
    {
        public void NumbersAboveRangeException(string numbersAboveRange)
        {
            throw new Exception("Numbers are above range " + numbersAboveRange);
        }
    }
}
