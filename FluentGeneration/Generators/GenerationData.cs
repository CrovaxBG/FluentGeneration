using System;

namespace FluentGeneration.Generators
{
    public class GenerationData
    {
        public Type Type { get; }
        public object Data { get; }

        public GenerationData(Type type, object data)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Data = data;
        }
    }
}