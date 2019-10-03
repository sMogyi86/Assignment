using Assignment.Numbers;
using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NumberGeneratorTests
    {
        private NumberGenerator generator;

        [SetUp]
        public void SetUp()
        {
            generator = new NumberGenerator();
        }

        [Test]
        public void GenerateEven_IncorrectLimitParameter_Throws_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateEven(-1));
        }

        [Test]
        public void GenerateEven_CorrectLimitParameter_GeneratesEvenNumber()
        {
            var limit = new Random().Next(0, int.MaxValue);

            var generatedNumber = generator.GenerateEven(limit);

            Assert.That(generatedNumber % 2 == 0, $"{nameof(generatedNumber)}: {generatedNumber} was with {nameof(limit)}: {limit}");
        }

        [Test]
        public void GenerateOdd_LimitParameterUnderThreshold_Throws_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => generator.GenerateOdd(0));
        }

        [Test]
        public void GenerateOdd_CorrectLimitParameter_GeneratesOddNumber()
        {
            var limit = new Random().Next(1, int.MaxValue);

            var generatedNumber = generator.GenerateOdd(limit);

            Assert.That(generatedNumber % 2 != 0, $"{nameof(generatedNumber)}: {generatedNumber} was with {nameof(limit)}: {limit}");
        }
    }
}