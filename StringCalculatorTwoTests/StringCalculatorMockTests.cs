using NSubstitute;
using StringCalculatorTwo.Services;
using NUnit.Framework;
using StringCalculatorTwo;
using System.Collections.Generic;

namespace StringCalculatorTwoTests
{
    public class StringCalculatorMockTests
    {
        StringCalculator _stringCalculator;
        IProcessNumbers _processNumbers;
        ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _processNumbers = Substitute.For<IProcessNumbers>();
            _calculator = Substitute.For<ICalculator>();
            _stringCalculator = new StringCalculator(_processNumbers, _calculator);
        }

        [Test]
        public void GivenStringNumbers_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1,2,3";
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 4, 5, 6 };
            int expected = -16;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 5, 6, 7 };
            int expected = -18;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 0, 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 0, 1, 2, 0 };
            int expected = -3;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

