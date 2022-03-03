using NSubstitute;
using StringCalculatorTwo.Services;
using NUnit.Framework;
using StringCalculatorTwo;

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
            int[] intNumbers = { 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 1, 4, 5, 6 };
            int expected = -16;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 5, 6, 7 };
            string[] delimiters = { "$$$", "###" };
            int expected = -18;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 0, 1, 2, 3 };
            int expected = -6;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
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
            int[] intNumbers = { 0, 1, 2, 0 };
            string[] delimiters = { "," };
            int expected = -3;

            //Act
            _delimiters.GetDelimiters(Arg.Any<string>()).Returns(delimiters);
            _split.SplitNumbers(Arg.Any<string>(), Arg.Any<string[]>(), Arg.Any<int>()).Returns(stringNumbers);
            _processNumbers.ConvertAndCheckNumbersAboverange(Arg.Any<string[]>()).Returns(intNumbers);
            _calculator.CalculateNumbers(Arg.Any<int[]>()).Returns(expected);
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

