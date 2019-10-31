using System;

namespace FluentGeneration.Shared
{
    [Flags]
    public enum AccessModifiers
    {
        None = 0,
        Const = 1,
        Static = 2,
        Readonly = 4,
        Volatile = 8,
    }
}