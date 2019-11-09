using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class SetBodyGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is BodyData bodyData)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (bodyData.IsAuto) { return "set;"; }
            if (string.IsNullOrEmpty(bodyData.Body)) { throw new InvalidOperationException($"{nameof(bodyData.Body)} contains no data for non-auto get."); }

            return $@"set {{ {bodyData.Body} }}";
        }
    }
}