using System;
using System.Collections.Generic;
using FluentGeneration.Generators;

namespace FluentGeneration.Containers
{
    public class PatternContainer : IPatternContainer
    {
        private bool _disposed;
        private Dictionary<Type, Type> _patternMap;

        public PatternContainer()
        {
            _patternMap = new Dictionary<Type, Type>();
        }

        public virtual IPatternContainer RegisterType<TFrom, TTo>()
            where TTo : IGeneratableHandler
        {
            return RegisterType(typeof(TFrom), typeof(TTo));
        }

        public virtual IPatternContainer RegisterType(Type registeredType, Type mappedToType)
        {
            if (registeredType == null) { throw new ArgumentNullException(nameof(registeredType)); }
            if (mappedToType == null) { throw new ArgumentNullException(nameof(mappedToType)); }

            if (!typeof(IGeneratableHandler).IsAssignableFrom(mappedToType))
            {
                throw new InvalidOperationException(
                    $"{nameof(mappedToType)} must inherit from {nameof(IGeneratableHandler)}!");
            }

            if (_patternMap.ContainsKey(registeredType))
            {
                throw new InvalidOperationException($"{nameof(registeredType)} is already registered!");
            }

            _patternMap.Add(registeredType, mappedToType);
            return this;
        }

        public virtual bool IsRegistered(Type type)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            return _patternMap.ContainsKey(type);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _patternMap = null;
            }

            _disposed = true;
        }

        public virtual IGeneratableHandler Resolve(Type type)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            if (!_patternMap.ContainsKey(type))
            {
                throw new InvalidOperationException($"{nameof(type)} is not registered!");
            }

            var targetType = _patternMap[type];
            return (IGeneratableHandler)Activator.CreateInstance(targetType);
        }
    }
}