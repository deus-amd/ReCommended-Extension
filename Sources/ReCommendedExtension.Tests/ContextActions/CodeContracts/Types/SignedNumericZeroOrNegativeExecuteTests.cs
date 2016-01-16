using JetBrains.ReSharper.TestFramework;
using NUnit.Framework;
using ReCommendedExtension.ContextActions.CodeContracts;

namespace ReCommendedExtension.Tests.ContextActions.CodeContracts.Types
{
    [TestNetFramework4]
    [TestFixture]
    public sealed class SignedNumericZeroOrNegativeExecuteTests : ContextActionExecuteTestBase<SignedNumericZeroOrNegative>
    {
        protected override string RelativeTestDataPath => @"ContextActions\CodeContracts\Types\SignedNumericZeroOrNegative";

        [Test]
        public void TestExecuteInt() => DoNamedTest2();

        [Test]
        public void TestExecuteLong() => DoNamedTest2();

        [Test]
        public void TestExecuteSbyte() => DoNamedTest2();

        [Test]
        public void TestExecuteShort() => DoNamedTest2();

        [Test]
        public void TestExecuteDecimal() => DoNamedTest2();

        [Test]
        public void TestExecuteDouble() => DoNamedTest2();

        [Test]
        public void TestExecuteFloat() => DoNamedTest2();
    }
}