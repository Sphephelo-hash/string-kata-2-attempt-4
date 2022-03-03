using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
