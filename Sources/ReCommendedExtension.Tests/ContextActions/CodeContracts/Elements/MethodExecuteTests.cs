using JetBrains.ReSharper.TestFramework;
using NUnit.Framework;
using ReCommendedExtension.ContextActions.CodeContracts;

namespace ReCommendedExtension.Tests.ContextActions.CodeContracts.Elements
{
    [TestNetFramework4]
    [TestFixture]
    public sealed class MethodExecuteTests : ContextActionExecuteTestBase<NotNull>
    {
        protected override string RelativeTestDataPath => @"ContextActions\CodeContracts\Elements\Method";

        [Test]
        public void TestExecuteWithEmptyMethod() => DoNamedTest2();

        [Test]
        public void TestExecuteWithNonEmptyMethod() => DoNamedTest2();

        [Test]
        public void TestExecuteWithNonEmptyMethod2() => DoNamedTest2();

        [Test]
        public void TestExecuteWithNonEmptyMethod3() => DoNamedTest2();

        [Test]
        public void TestExecuteWithAbstractMethod() => DoNamedTest2();

        [Test]
        public void TestExecuteWithAbstractMethod2() => DoNamedTest2();

        [Test]
        public void TestExecuteWithAbstractMethod3() => DoNamedTest2();

        [Test]
        public void TestExecuteWithInterfaceMethod() => DoNamedTest2();
    }
}