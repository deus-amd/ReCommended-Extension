using JetBrains.ReSharper.TestFramework;
using NUnit.Framework;
using ReCommendedExtension.ContextActions.CodeContracts;

namespace ReCommendedExtension.Tests.ContextActions.CodeContracts.Types
{
    [TestNetFramework4]
    [TestFixture]
    public sealed class CollectionAllItemsNotNullExecuteTests : ContextActionExecuteTestBase<CollectionAllItemsNotNull>
    {
        protected override string RelativeTestDataPath => @"ContextActions\CodeContracts\Types\CollectionAllItemsNotNull";

        [Test]
        public void TestExecuteGenericCollection() => DoNamedTest2();

        [Test]
        public void TestExecuteArray() => DoNamedTest2();

        [Test]
        public void TestExecuteDictionary() => DoNamedTest2();

        [Test]
        public void TestExecuteCollection() => DoNamedTest2();
    }
}