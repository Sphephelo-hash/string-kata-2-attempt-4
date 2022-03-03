using NUnit.Framework;
using StringCalculatorTwo;
using StringCalculatorTwo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTwoTests
{
    class StringCalculatorTests
    {
        public class StringCalculatorMockTests
        {
            StringCalculator _stringCalculator;

            [SetUp]
            public void SetUp()
            {

                _stringCalculator = new StringCalculator(new Delimiters(), new Split(), new ProcessNumbers(new OutOfBoundsExceptions()), new SubtractOperation());
            }

            [Test]
            public void GivenStringNumbers_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "1,2,3";
                int expected = -6;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringNumbersWithNewLines_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "1,2\n3";
                int expected = -6;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringNumbersWithCustomdelimiter_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "##;\n1;2;3";
                int expected = -6;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringNumbersWithDelimiterOfDifferentLength_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "##[***]\n1***2***3";
                int expected = -6;

                //Act

                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }
            [Test]
            public void GivenStringNumbersWithMultipleCustomDelimiters_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "##[;][$$$]\n1;2$$$3";
                int expected = -6;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringNumbersWithDelimiterSeparators_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "<(>)##(*)\n1*2*3";
                int expected = -6;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringNumbersWithDelimiterSeparators2_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "<>><##>&<\n1&4&5&6";
                int expected = -16;

                //Act                
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }
            [Test]
            public void GivenStringNumbersWithDelimiterSeparatorsAndMultipleDelimiters_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "<<>>##<$$$><###>\n5$$$6###7";
                int expected = -18;

                //Act             
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringCharacters_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "a,b,c,d";
                int expected = -6;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }

            [Test]
            public void GivenStringCharacters2_WhenCalculating_ReturnDifference()
            {
                //Arrange
                string input = "a,b,c,p";
                int expected = -3;

                //Act
                int result = _stringCalculator.Subtract(input);

                //Assert
                Assert.AreEqual(expected, result);
            }
        }
    }
}