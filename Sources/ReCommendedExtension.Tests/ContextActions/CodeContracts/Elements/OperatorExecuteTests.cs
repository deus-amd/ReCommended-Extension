using JetBrains.ReSharper.TestFramework;
using NUnit.Framework;
using ReCommendedExtension.ContextActions.CodeContracts;

namespace ReCommendedExtension.Tests.ContextActions.CodeContracts.Elements
{
    [TestNetFramework4]
    [TestFixture]
    public sealed class OperatorExecuteTests : ContextActionExecuteTestBase<NotNull>
    {
        protected override string RelativeTestDataPath => @"ContextActions\CodeContracts\Elements\Operator";

        [TestCase("ExecuteConversion.cs")]
        [TestCase("ExecuteOverload.cs")]
        [TestCase("ExecuteOverloadNonEmpty.cs")]
        public void TestFile(string file) => DoTestSolution(file);
    }
}