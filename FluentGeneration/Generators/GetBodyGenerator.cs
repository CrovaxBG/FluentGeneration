using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class GetBodyGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is BodyData bodyData)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (bodyData.IsAuto) { return "get;"; }
            if (string.IsNullOrEmpty(bodyData.Body)) { throw new InvalidOperationException($"{nameof(bodyData.Body)} contains no data for non-auto get.");}

            return $@"get {{ {bodyData.Body} }}";
        }
    }
}