using Assignment.Numbers;
using Assignment.Strings;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    [TestFixture]
    public class StringGeneratorTest
    {
        private Mock<INumberGenerator> numberGeneratorMock;
        private StringGenerator stringGenerator;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.numberGeneratorMock = new Mock<INumberGenerator>();
            this.numberGeneratorMock.Setup(m => m.GenerateEven(It.IsAny<int>())).Returns(2);
            this.numberGeneratorMock.Setup(m => m.GenerateOdd(It.IsAny<int>())).Returns(1);

            this.stringGenerator = new StringGenerator(numberGeneratorMock.Object);
        }

        [Test]
        public void GenerateEvenOddPairs_PairCountLessThanOne_Throws_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => this.stringGenerator.GenerateEvenOddPairs(0, 10));

        [Test]
        public void GenerateEvenOddPairs_PairCountGreaterThanOne_ReturnsListWithTheSameCount()
        {
            var pairCount = 4;
            var resultList = this.stringGenerator.GenerateEvenOddPairs(pairCount, 3);


            Assert.AreEqual(pairCount, resultList.Count);
        }

        [Test]
        public void GenerateEvenOddPairs_PairCountGreaterThanOne_ReturnsTheListWithThePairs()
        {
            var pairCount = 4;
            var expectedList = new List<string>() { "2,1", "2,1", "2,1", "2,1" };

            var resultList = this.stringGenerator.GenerateEvenOddPairs(pairCount, 1);

            Assert.IsTrue(Enumerable.SequenceEqual(expectedList, resultList));
        }
    }
}
