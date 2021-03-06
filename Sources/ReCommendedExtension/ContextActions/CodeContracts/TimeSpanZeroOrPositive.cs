using JetBrains.Annotations;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Impl.Types;
using JetBrains.ReSharper.Psi.Tree;

namespace ReCommendedExtension.ContextActions.CodeContracts
{
    [ContextAction(Group = "C#", Name = "Add contract: time span is zero or positive" + ZoneMarker.Suffix,
        Description = "Adds a contract that a time span is greater than or equal to zero.")]
    public sealed class TimeSpanZeroOrPositive : TimeSpan
    {
        public TimeSpanZeroOrPositive([NotNull] ICSharpContextActionDataProvider provider) : base(provider) { }

        protected override string GetContractTextForUI(string contractIdentifier) => $"{contractIdentifier} >= {nameof(System.TimeSpan.Zero)}";

        protected override IExpression GetExpression(CSharpElementFactory factory, IExpression contractExpression)
            =>
                factory.CreateExpression(
                    string.Format("$0 >= $1.{0}", nameof(System.TimeSpan.Zero)),
                    contractExpression,
                    new DeclaredTypeFromCLRName(ClrTypeNames.TimeSpan, Provider.PsiModule).GetTypeElement());
    }
}