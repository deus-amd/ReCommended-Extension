using System.Diagnostics;
using JetBrains.Annotations;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Impl.Types;
using JetBrains.ReSharper.Psi.Tree;

namespace ReCommendedExtension.ContextActions.CodeContracts
{
    [ContextAction(Group = "C#", Name = "Add contract: time span is zero" + ZoneMarker.Suffix,
        Description = "Adds a contract that a time span is zero.")]
    public sealed class TimeSpanZero : TimeSpan
    {
        public TimeSpanZero([NotNull] ICSharpContextActionDataProvider provider) : base(provider) { }

        protected override string GetContractTextForUI(string contractIdentifier)
            => string.Format("{0} == {1}", contractIdentifier, nameof(System.TimeSpan.Zero));

        protected override IExpression GetExpression(CSharpElementFactory factory, IExpression contractExpression)
        {
            Debug.Assert(Provider.PsiModule != null);

            return factory.CreateExpression(
                string.Format("$0 == $1.{0}", nameof(System.TimeSpan.Zero)),
                contractExpression,
                new DeclaredTypeFromCLRName(ClrTypeNames.TimeSpan, Provider.PsiModule).GetTypeElement());
        }
    }
}