using Assignment.Numbers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NumberUtilsTests
    {
        const string even = "even";
        const string odd = "odd";

        private NumberUtils utils;

        [SetUp]
        public void SetUp()
            => utils = new NumberUtils();

        [Test]
        public void GetDivisors_NegativeNumber_Throws_ArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => utils.GetDivisors(-1));

        [TestCase(10, new int[] { 1, 2, 5, 10 })]
        [TestCase(1, new int[] { 1 })]
        [TestCase(9, new int[] { 1, 3, 9 })]
        public void GetDivisors_PositiveNumber_ReturnsWithAllDivisors(int num, IEnumerable<int> expectedDivisors)
            => Assert.IsTrue(Enumerable.SequenceEqual(
                expectedDivisors.OrderBy(n => n)
                , utils.GetDivisors(num).OrderBy(n => n)));

        [TestCase(-1, false)]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void IsPrime_AnyNumber_Decides(int number, bool expectedIsPrime)
            => Assert.AreEqual(expectedIsPrime, utils.IsPrime(number));

        [TestCase(-2, even)]
        [TestCase(-1, odd)]
        [TestCase(0, even)]
        [TestCase(1, odd)]
        [TestCase(2, even)]
        public void EvenOrOdd_AnyNumber_Decides(int number, string expectedResult)
            => Assert.AreEqual(expectedResult, utils.EvenOrOdd(number));

    }
}
