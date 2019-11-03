using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodBody<T> : IMethodBody<T>
        where T : IGeneratedObject
    {
        public Func<T> Source { get; set; }

        public T WithEmptyBody()
        {
            var source = Source.Invoke();
            source.Generator.AddGenerationData(typeof(IMethodBody<>), new BodyData{IsAuto = true});
            return source;
        }

        public T WithMethodBody(string body)
        {
            var source = Source.Invoke();
            source.Generator.AddGenerationData(typeof(IMethodBody<>), new BodyData { IsAuto = false, Body = body});
            return source;
        }
    }
}