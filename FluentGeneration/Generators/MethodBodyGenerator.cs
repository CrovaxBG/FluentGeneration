using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class MethodBodyGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is BodyData bodyData)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (bodyData.IsAuto) { return ";"; }

            return $@"{{ {bodyData.Body} }}";
        }
    }
}