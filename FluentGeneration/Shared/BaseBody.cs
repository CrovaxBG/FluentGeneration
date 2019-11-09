using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentGeneration.Factories;
using FluentGeneration.Generators;

namespace FluentGeneration.Shared
{
    public delegate IEnumerable<T> SequenceGenerator<T>(Func<T> value);

    public abstract class BaseBody<TBody, TSource>
        where TBody : IFluentLink<TSource>
    {
        protected abstract Func<TBody> GetSource { get; }

        protected virtual IFactory<IFluentLink<TBody>> Factory { get; }
        protected virtual IGenerator Generator { get; }

        protected BaseBody(IGenerator generator, IFactory<IFluentLink<TBody>> factory)
        {
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        protected virtual TObject WithObject<TObject>()
        {
            var instance = Factory.Create(typeof(TObject));
            instance.Source = GetSource;
            return (TObject)instance;
        }

        protected virtual TBody WithMultipleObjects<T>(SequenceGenerator<T> sequenceGenerator)
            where T : IEndable<TBody>
        {
            var sequence = sequenceGenerator.Invoke(WithObject<T>);
            foreach (var element in sequence)
            {
                element.End(); //force generation
            }

            return GetSource.Invoke();
        }
    }
}
