﻿using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CodeAnnotations;
using JetBrains.ReSharper.Psi.CSharp.Impl;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace ReCommendedExtension.Assertions
{
    internal sealed class InlineAssertion : Assertion
    {
        internal static InlineAssertion TryFromInvocationExpression([NotNull] IInvocationExpression invocationExpression)
        {
            var referenceExpression = invocationExpression.InvokedExpression as IReferenceExpression;
            var qualifierExpression = referenceExpression?.QualifierExpression;
            if (qualifierExpression != null)
            {
                var method = referenceExpression.Reference.Resolve().DeclaredElement as IMethod;
                if (method != null && method.ShortName.StartsWith("AssertNotNull", StringComparison.Ordinal) && method.IsExtensionMethod &&
                    method.Parameters.Count == 1)
                {
                    Debug.Assert(method.Parameters[0] != null);

                    if (method.Parameters[0].Type.Equals(method.ReturnType))
                    {
                        var methodDeclaration = method.GetSingleDeclaration<IMethodDeclaration>();
                        if (methodDeclaration != null &&
                            methodDeclaration.AttributesEnumerable.Any(
                                attribute =>
                                    attribute.AssertNotNull().GetAttributeInstance().GetAttributeType().GetClrName().FullName ==
                                    ClrTypeNames.DebuggerStepThroughAttribute.FullName) &&
                            methodDeclaration.AttributesEnumerable.Any(
                                attribute =>
                                    attribute.AssertNotNull().GetAttributeInstance().GetAttributeType().GetClrName().ShortName ==
                                    NullnessProvider.NotNullAttributeShortName))
                        {
                            return new InlineAssertion(invocationExpression, qualifierExpression, method.ShortName);
                        }
                    }
                }
            }

            return null;
        }

        InlineAssertion(
            [NotNull] IInvocationExpression invocationExpression,
            [NotNull] ICSharpExpression qualifierExpression,
            [NotNull] string methodName)
        {
            InvocationExpression = invocationExpression;
            QualifierExpression = qualifierExpression;
            MethodName = methodName;
        }

        public override AssertionConditionType AssertionConditionType => AssertionConditionType.IS_NOT_NULL;

        /// <remarks>
        /// The complete expression including the qualifier (part before the "AssertNotNull") and the "AssertNotNull" invocation.
        /// </remarks>
        [NotNull]
        public IInvocationExpression InvocationExpression { get; }

        /// <remarks>
        /// The expression part before the "AssertNotNull" method.
        /// </remarks>
        [NotNull]
        public ICSharpExpression QualifierExpression { get; }

        /// <remarks>
        /// The exact "AssertNotNull" method name.
        /// </remarks>
        [NotNull]
        public string MethodName { get; }

        public override bool Equals(Assertion other)
            => InvocationExpression.GetDocumentRange() == (other as InlineAssertion)?.InvocationExpression.GetDocumentRange();

        public override int GetHashCode() => InvocationExpression.GetDocumentRange().GetHashCode();
    }
}