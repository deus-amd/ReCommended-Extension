﻿using System.Diagnostics.CodeAnalysis;

namespace Test
{
    [SuppressMessage("C", "Id")]
    internal class Class
    {
        [SuppressMessage("C", "Id", Justification = "")]
        void Foo() { }
    }
}