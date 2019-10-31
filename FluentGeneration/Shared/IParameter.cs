using System;

namespace FluentGeneration.Shared
{
    public interface IParameter
    {
        ParameterModifier ParameterModifier { get; set; }
        Type ParameterType { get; set; }
        string ParameterName { get; set; }
        Type[] ParameterAttributes { get; set; }
    }
}