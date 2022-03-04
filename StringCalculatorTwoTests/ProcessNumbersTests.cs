using NUnit.Framework;
using StringCalculatorTwo.Services;
using NSubstitute;
using System.Collections.Generic;
using System;

namespace StringCalculatorTwoTests
{
    public class ProcessNumbersTests
    {
        IProcessNumbers _convertNumbers;
        ISplit _split;
        ICustomExceptions _exceptions;

        [SetUp]
        public void SetUp()
        {
            _exceptions = Substitute.For<ICustomExceptions>();
            _split = Substitute.For<ISplit>();
            _convertNumbers = new ProcessNumbers(_exceptions, _split);
        }

        [Test]
        public void GivenStringNumbers_WhenConverting_ReturnsIntegerNumbers()
        {
            //Arrange 
            string[] input = { "1", "2", "3" };
            List<int> expected = new List<int>() { 1, 2, 3 };

            //Act
            List<int> result = _convertNumbers.ConvertStringNumbersToInt(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersAndLetters_WhenConverting_ReturnsIntegerNumbers()
        {
            //Arrange 
            string[] input = { "1", "c", "m" };
            List<int> expected = new List<int>() { 1, 2, 0 };

            //Act
            List<int> result = _convertNumbers.ConvertStringNumbersToInt(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersAbove10000_WhenConverting_ThrowsException()
        {
            // Arrange 
            List<int> stringNumbers = new List<int>{ 1, 2, 10001 };
            _exceptions.When(x => x.NumbersAboveRangeException(Arg.Any<string>()))
                .Do(x => throw new Exception("Numbers are above range "));
            string expected = "Numbers are above range ";

            // Act
            var results = Assert.Throws<System.Exception>(() => _convertNumbers.CheckForNumbersAboveRange(stringNumbers));

            //assert
            Assert.AreEqual(expected, results.Message);
        }
    }
}