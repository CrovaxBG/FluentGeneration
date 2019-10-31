using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FluentGeneration
{
    public interface IPatternContainer : IDisposable
    {
        IPatternContainer RegisterType(Type registeredType, Type mappedToType);
        IPatternContainer RegisterType<TFrom, TTo>() where TTo : IGeneratableHandler;
        bool IsRegistered(Type type);
        object Resolve(Type type);
    }

    public class CodeGenerator : IGenerator
    {
        protected Dictionary<Type, object> GenerationData;

        private const string SectionPattern = @"\{(.*?)\}";
        private const string TypePattern = @"\[(.*?)\]";

        private readonly IFactory<IGeneratableHandler> _factory;

        public CodeGenerator(IFactory<IGeneratableHandler> factory)
        {
            _factory = factory;
        }

        public string Generate(string pattern)
        {
            var typeTokens = ExtractTypeTokens(pattern);

            var filteredTokens = VerifyTypeTokens(typeTokens);

            foreach (var data in GenerationData.Where(data => filteredTokens.Contains(data.Key.Name)))
            {
                pattern = ReplaceTypeToken(pattern, new GenerationData(data.Key, data.Value));
                filteredTokens.Remove(data.Key.Name);
            }

            foreach (var token in filteredTokens)
            {
                ClearSection(pattern, token);
            }

            return pattern;
        }

        private IEnumerable<string> ExtractTypeTokens(string pattern)
        {
            return Regex.Matches(pattern, TypePattern, RegexOptions.IgnoreCase)
                .Select(m => m.Groups[1].Value);
        }

        private HashSet<string> VerifyTypeTokens(IEnumerable<string> typeTokens)
        {
            //Not using HashSet<string>(IEnumerable<> source) because we want to throw exception
            //if there are duplicates, this means there is problem in the pattern, and not just swallow it silently
            var filteredTokens = new HashSet<string>();
            if (typeTokens.Any(type => !filteredTokens.Add(type)))
            {
                throw new InvalidOperationException(@"Generated object pattern cannot contain duplicate types!");
            }

            return filteredTokens;
        }

        private string ReplaceTypeToken(string currentCode, GenerationData data)
        {
            var instance = _factory.Create(data.Type);
            var generatedCode = instance.Generate(data);
            var typeToken = $"[{data.Type.Name}]";
            return currentCode.Replace(typeToken, generatedCode);
        }

        private string ClearSection(string currentCode, string typeToken)
        {
            var pattern = $@"\{{(.*?)\[ {typeToken}\](.*?)\}}";
            return Regex.Replace(currentCode, pattern, string.Empty);
        }

        public virtual void AddGenerationData(Type type, object data)
        {
            if (type == null) { return; }

            if (GenerationData.ContainsKey(type))
            {
                return;
            }

            GenerationData.Add(type, data);
        }
    }

    public class PatternContainer : IPatternContainer
    {
        private bool _disposed = false;
        private Dictionary<Type, Type> _patternMap;

        public IPatternContainer RegisterType<TFrom, TTo>()
            where TTo : IGeneratableHandler
        {
            return RegisterType(typeof(TFrom), typeof(TTo));
        }

        public IPatternContainer RegisterType(Type registeredType, Type mappedToType)
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

        public bool IsRegistered(Type type)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            return _patternMap.ContainsKey(type);
        }

        public object Resolve(Type type)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            if (!_patternMap.ContainsKey(type))
            {
                throw new InvalidOperationException($"{nameof(type)} is not registered!");
            }

            var targetType = _patternMap[type];
            return Activator.CreateInstance(targetType);
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
    }

    public interface IPatternResolver
    {
        IGeneratableHandler Resolve(Type type);
    }

    public class PatternResolver : IPatternResolver
    {
        private readonly IPatternContainer _container;

        public PatternResolver(IPatternContainer container)
        {
            _container = container;
        }

        public IGeneratableHandler Resolve(Type type)
        {
            return (IGeneratableHandler)_container.Resolve(type);
        }
    }
}
