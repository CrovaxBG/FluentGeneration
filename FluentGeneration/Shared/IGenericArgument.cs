using System;

namespace FluentGeneration.Shared
{
    public interface IGenericArgument
    {
        string Name { get; set; }
        public GenericArgumentType Type { get; set; }
    }
}