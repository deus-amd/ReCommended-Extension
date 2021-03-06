using System;
using System.Diagnostics;
using JetBrains.Annotations;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Impl.Types;
using JetBrains.ReSharper.Psi.Tree;

namespace ReCommendedExtension.ContextActions.CodeContracts
{
    [ContextAction(Group = "C#", Name = "Add contract: number is not 0" + ZoneMarker.Suffix,
        Description = "Adds a contract that a number (signed) is not 0.")]
    public sealed class SignedNumericNonZero : SignedNumeric
    {
        public SignedNumericNonZero([NotNull] ICSharpContextActionDataProvider provider) : base(provider) {}

        protected override string GetContractTextForUI(string contractIdentifier) => $"{contractIdentifier} != 0";

        protected override IExpression GetExpression(CSharpElementFactory factory, IExpression contractExpression)
        {
            Debug.Assert(NumericTypeInfo != null);

            return NumericTypeInfo.EpsilonLiteral != null
                ? factory.CreateExpression(
                    string.Format("$1.{0}($0 - 0{1}) > {2}", nameof(Math.Abs), NumericTypeInfo.LiteralSuffix, NumericTypeInfo.EpsilonLiteral),
                    contractExpression,
                    new DeclaredTypeFromCLRName(ClrTypeNames.Math, Provider.PsiModule).GetTypeElement())
                : factory.CreateExpression(string.Format("$0 != 0{0}", NumericTypeInfo.LiteralSuffix), contractExpression);
        }
    }
}