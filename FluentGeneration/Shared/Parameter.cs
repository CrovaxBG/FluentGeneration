using System;

namespace FluentGeneration.Shared
{
    public class Parameter : IParameter
    {
        public ParameterModifier ParameterModifier { get; set; }
        public Type ParameterType { get; set; }
        public string ParameterName { get; set; }
        public Type[] ParameterAttributes { get; set; }

        public static IParameter Standard(Type parameterType, string parameterName, params Type[] parameterAttributes)
        {
            return new Parameter
            {
                ParameterModifier = ParameterModifier.Standard,
                ParameterType = parameterType,
                ParameterName = parameterName,
                ParameterAttributes = parameterAttributes
            };
        }

        public static IParameter Ref(Type parameterType, string parameterName, params Type[] parameterAttributes)
        {
            return new Parameter
            {
                ParameterModifier = ParameterModifier.Ref,
                ParameterType = parameterType,
                ParameterName = parameterName,
                ParameterAttributes = parameterAttributes
            };
        }

        public static IParameter Out(Type parameterType, string parameterName, params Type[] parameterAttributes)
        {
            return new Parameter
            {
                ParameterModifier = ParameterModifier.Out,
                ParameterType = parameterType,
                ParameterName = parameterName,
                ParameterAttributes = parameterAttributes
            };
        }
    }
}