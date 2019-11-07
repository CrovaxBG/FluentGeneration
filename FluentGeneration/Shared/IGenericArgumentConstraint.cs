using System;

namespace FluentGeneration.Shared
{
    public interface IGenericArgumentConstraint
    {
        string GenericArgumentName { get; set; }
        Type[] Constraints { get; set; }
    }
}