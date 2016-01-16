﻿using System.Diagnostics;
using JetBrains.Annotations;

namespace Test
{
    internal static class Execute
    {
        static void Method(string one)
        {
            var length = one.AssertN{caret}otNull().Length;
        }

        [DebuggerStepThrough]
        [NotNull]
        static T AssertNotNull<T>(this T value) where T : class
        {
            Debug.Assert(value != null);

            return value;
        }
    }
}