﻿using System.Collections.Generic;

namespace StringCalculatorTwo
{
    public class SubtractOperation : ICalculator
    {
        public int CalculateNumbers(List<int> numbers)
        {
            int difference = 0;
            foreach (int number in numbers)
            {
                difference -= number;
            }

            return difference;
        }
    }
}
