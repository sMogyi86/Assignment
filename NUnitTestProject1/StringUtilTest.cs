using Assignment.Strings;
using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
    [TestFixture]
    public class StringUtilTest
    {
        private StringUtilFactory stringUtilFactory;
        private IStringUtil stringUtil;

        [OneTimeSetUp]
        public void OneTimeSetUp()
            => this.stringUtilFactory = new StringUtilFactory();

        [SetUp]
        public void SetUp()
            => this.stringUtil = this.stringUtilFactory.Create();

        [Test]
        public void IsPalindrom_NULLstr_Throws_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => this.stringUtil.IsPalindrom(null));

        [TestCase("", true)]
        [TestCase("a", true)]
        [TestCase("aba", true)]
        [TestCase("abba", true)]
        [TestCase("abc", false)]
        [TestCase("abcd", false)]
        public void IsPalindrom_DifferentValidInputs_(string str, bool expectedIsPalindrom)
            => Assert.AreEqual(expectedIsPalindrom, this.stringUtil.IsPalindrom(str));

    }
}
