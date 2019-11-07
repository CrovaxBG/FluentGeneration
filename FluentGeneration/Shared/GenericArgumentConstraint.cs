using System;

namespace FluentGeneration.Shared
{
    public class GenericArgumentConstraint : IGenericArgumentConstraint
    {
        public string GenericArgumentName { get; set; }
        public Type[] Constraints { get; set; }
    }
}