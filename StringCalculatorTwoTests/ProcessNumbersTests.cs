using NUnit.Framework;
using StringCalculatorTwo.Services;
using NSubstitute;

namespace StringCalculatorTwoTests
{
    public class ProcessNumbersTests
    {
        IProcessNumbers _convertNumbers;
        IExceptions _exceptions;
        [SetUp]
        public void SetUp()
        {
            _exceptions = Substitute.For<IExceptions>();
            _convertNumbers = new ProcessNumbers(_exceptions);
        }

        [Test]
        public void GivenStringNumbers_WhenConverting_ReturnsIntegerNumbers()
        {
            //Arrange 
            string[] input = { "1", "2", "3" };
            int[] expected = { 1, 2, 3 };

            //Act
            int[] result = _convertNumbers.ConvertStringNumbersToInt(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersAndLetters_WhenConverting_ReturnsIntegerNumbers()
        {
            //Arrange 
            string[] input = { "1", "c", "m" };
            int[] expected = { 1, 2, 0 };

            //Act
            int[] result = _convertNumbers.ConvertStringNumbersToInt(input);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}