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
        IDelimiters _delimiters;
        IProcessNumbers _processNumbers;
        ICalculator _calculator;
        ISplit _split;

        [SetUp]
        public void SetUp()
        {
            _delimiters = Substitute.For<IDelimiters>();
            _processNumbers = Substitute.For<IProcessNumbers>();
            _calculator = Substitute.For<ICalculator>();
            _split = Substitute.For<ISplit>();
            _stringCalculator = new StringCalculator(_delimiters, _split, _processNumbers, _calculator);
        }

        [Test]
        public void GivenStringNumbers_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1,2,3";
            string[] delimiters = { "\n", "," };
            string[] stringNumbers = { "1", "2", "3" };
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 0).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "1", "2", "3" };
            string[] delimiters = { "\n", "," };
            List<int> intNumbers = new List<int>(){ 1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 0).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "1", "2", "3" };
            string[] delimiters = { ";" };
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 3).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] delimiters = { "***" };
            string[] stringNumbers = { "1", "2", "3" };
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 7).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "1", "2", "3" };
            string[] delimiters = { ";", "$$$" };
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 9).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "1", "2", "3" };
            string[] delimiters = { "*" };
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 9).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "1", "4", "5", "6" };
            string[] delimiters = { "&" };
            List<int> intNumbers = new List<int>() { 1, 4, 5,6 };
            int expected = -16;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 10).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "5", "6", "7" };
            List<int> intNumbers = new List<int>() { 5, 6, 7 };
            string[] delimiters = { "$$$", "###" };
            int expected = -18;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 16).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "a", "b", "c", "d" };
            string[] delimiters = { "," };
            List<int> intNumbers = new List<int>() { 0,1, 2, 3 };
            int expected = -6;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 0).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
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
            string[] stringNumbers = { "a", "b", "c", "p" };
            List<int> intNumbers = new List<int>() { 0,1, 2, 0 };
            string[] delimiters = { "," };
            int expected = -3;

            _delimiters.GetDelimiters(input).Returns(delimiters);
            _split.SplitNumbers(input, delimiters, 0).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(stringNumbers).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

