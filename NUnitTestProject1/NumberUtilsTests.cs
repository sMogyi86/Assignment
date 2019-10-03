using Assignment.Numbers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NumberUtilsTests
    {
        private NumberUtils utils;

        [SetUp]
        public void SetUp()
        {
            utils = new NumberUtils();
        }

        [Test]
        public void GetDivisors_NegativeNumber_Throws_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => utils.GetDivisors(-1));
        }

        [TestCase(10, new int[] { 1, 2, 5, 10})]
        [TestCase(1, new int[] { 1})]
        [TestCase(9, new int[] { 1, 3, 9})]
        public void GetDivisors_PositiveNumber_ReturnsWithDivisors(int num, IEnumerable<int> expectedDivisors)
        {
            var divisors = utils.GetDivisors(num);


            Assert.IsTrue(Enumerable.SequenceEqual(
                expectedDivisors.OrderBy(n =>n)
                , divisors.OrderBy(n => n)));
        }
    }
}
