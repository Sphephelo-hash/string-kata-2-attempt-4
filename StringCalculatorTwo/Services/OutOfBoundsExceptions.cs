using System;

namespace StringCalculatorTwo.Services
{
    public class OutOfBoundsExceptions : ICustomExceptions
    {
        public void NumbersAboveRangeException(string numbersAboveRange)
        {
            throw new Exception("Numbers are above range" + numbersAboveRange);
        }
    }
}
