using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace FluentGeneration
{
    public class GenerationBuilder
    {
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IPatternResolver _patternResolver;

        public GenerationBuilder()
            : this(null, null)
        {
        }

        public GenerationBuilder(IDependencyResolver dependencyResolver, IPatternResolver patternResolver)
        {
            _dependencyResolver = dependencyResolver;
            _patternResolver = patternResolver;

            if (_dependencyResolver == null)
            {
                var container = SetupDIContainer();
                _dependencyResolver = new UnityResolver(container);
            }

            if (_patternResolver == null)
            {
                var container = SetupPatternContainer();
                _patternResolver = new PatternResolver(container);
            }
        }

        private IUnityContainer SetupDIContainer()
        {
            var container = new UnityContainer();
            container.RegisterType(typeof(IPatternContainer), typeof(PatternContainer));
            container.RegisterType(typeof(IPatternResolver), typeof(PatternResolver));
            container.RegisterType(typeof(IFactory<>), typeof(AbstractFactory<>));
            container.RegisterType(typeof(IFactory<IGeneratableHandler>), typeof(PatternFactory));
            container.RegisterType(typeof(IGenerator), typeof(CodeGenerator));
            container.RegisterType(typeof(IFieldAccessSpecifier<>), typeof(FieldAccessSpecifier<>));
            container.RegisterType(typeof(IFieldAccessModifier<>), typeof(FieldAccessModifier<>));
            container.RegisterType(typeof(IFieldType<>), typeof(FieldType<>));
            container.RegisterType(typeof(IFieldName<>), typeof(FieldName<>));
            container.RegisterType(typeof(IFieldAttribute<>), typeof(FieldAttribute<>));
            container.RegisterType(typeof(IFieldValue<>), typeof(FieldValue<>));
            container.RegisterType(typeof(IField<>), typeof(Field<>));

            return container;
        }

        private IPatternContainer SetupPatternContainer()
        {
            var container = new PatternContainer();
            container.RegisterType(typeof(IFieldAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IFieldAccessModifier<>), typeof(AccessModifierGenerator));
            container.RegisterType(typeof(IFieldType<>), typeof(TypeGenerator));
            container.RegisterType(typeof(IFieldName<>), typeof(NameGenerator));
            container.RegisterType(typeof(IFieldAttribute<>), typeof(AttributeGenerator));
            container.RegisterType(typeof(IFieldValue<>), typeof(ValueGenerator));

            return container;
        }

        public void DefineFile()
        {

        }

        public IClass DefineClass()
        {
            IClass generatedClass = null;
            //separate classes for each main type
            generatedClass
                .WithField()
                    .Begin()
                        .WithAccessSpecifier(AccessSpecifier.Private).WithAccessModifier(AccessModifiers.None)
                        .WithType(typeof(string)).WithName("_count").WithAttributes(typeof(RequiredAttribute))
                        .WithNoValue()
                    .End()
                //.WithProperty()
                //    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                //    .WithType(typeof(string)).WithName("Count").WithAttributes(typeof(RequiredAttribute))
                //    .WithGetAccessSpecifier(AccessSpecifier.None).WithGetBody("qweqwe")
                //    .WithSetAccessSpecifier(AccessSpecifier.None).WithSetBody("qwewqe")
                //    .WithPropertyValue(null)
                //    .Build()
                //.WithMethod()
                //    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                //    .WithType(typeof(void)).WithName("Method1").WithAttributes()
                //    .WithParameters(Parameter.Standard(typeof(int), "x"), Parameter.Ref(typeof(int), "y"), Parameter.Out(typeof(int), "z"))
                //    .WithMethodBody("z = x + y;")
                //    .Build()
                .Build();
            return null;
        }

        public IInterface DefineInterface()
        {
            return null;
        }
    }

    #region General

    public interface IStorageContainer<T>
        where T : IStorageContainer<T>, IGeneratedObject
    {
        void AddField(IField<T> field);
        void AddProperty(IProperty<T> property);
        void AddMethod(IMethod<T> method);
    }

    public interface IFluentContainer<T>
        where T : IStorageContainer<T>, IGeneratedObject
    {
        IProperty<T> WithProperty();
        IField<T> WithField();
        IMethod<T> WithMethod();
    }

    public interface IGeneratedObject
    {
        IGenerator Generator { get; }
        string Data { get; }
    }

    public enum ParameterModifier
    {
        Standard,
        Ref,
        Out,
    }

    public enum AccessSpecifier
    {
        None,
        Private,
        Protected,
        ProtectedInternal,
        Internal,
        Public
    }

    [Flags]
    public enum AccessModifiers
    {
        None = 0,
        Const = 1,
        Readonly = 2,
        Static = 4,
        Volatile = 8,
    }

    public interface IBeginable<out T>
    {
        T Begin();
    }

    public interface IFluentLink<T>
        where T : IGeneratedObject
    {
        T Source { get; set; }
    }

    public interface IEndable<out T>
    {
        T End();
    }

    public interface IParameter
    {
        ParameterModifier ParameterModifier { get; set; }
        Type ParameterType { get; set; }
        string ParameterName { get; set; }
        Type[] ParameterAttributes { get; set; }
    }

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

    #endregion

    #region Field Interfaces

    public interface IFieldAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }

    public interface IFieldAccessModifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldType<T> WithAccessModifier(AccessModifiers accessModifier);
    }

    public interface IFieldType<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldName<T> WithType(Type type);
    }

    public interface IFieldName<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldAttribute<T> WithName(string name);
    }

    public interface IFieldAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldValue<T> WithAttributes(params Type[] attributeTypes);
    }

    public interface IFieldValue<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        T WithNoValue();
        T WithValue(object value);
    }

    public interface IField<T> :
        IGeneratedObject, IFluentLink<T>,
        IBeginable<IFieldAccessSpecifier<IField<T>>>, IEndable<T>
        where T : IStorageContainer<T>, IGeneratedObject
    {
    }

    #endregion

    #region Field Implementation

    public class Field<T> : IField<T>
        where T : IStorageContainer<T>, IGeneratedObject
    {
        public IGenerator Generator { get; }
        public string Data { get; private set; }
        public T Source { get; set; }

        private readonly IFieldAccessSpecifier<IField<T>> _accessSpecifier;

        public Field(IGenerator generator, IFieldAccessSpecifier<IField<T>> accessSpecifier)
        {
            Generator = generator;
            _accessSpecifier = accessSpecifier;
            _accessSpecifier.Source = this;
        }

        public IFieldAccessSpecifier<IField<T>> Begin()
        {
            return _accessSpecifier;
        }

        public T End()
        {
            Data = Generator.Generate(PatternConfig.FieldPattern);
            Source.Generator.AddGenerationData(typeof(IField<>), Data);
            return Source;
        }
    }

    public class FieldAccessSpecifier<T> : IFieldAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IFieldAccessModifier<T> _fieldAccessModifier;
        public T Source { get; set; }

        public FieldAccessSpecifier(IFieldAccessModifier<T> fieldAccessModifier)
        {
            _fieldAccessModifier = fieldAccessModifier;
            _fieldAccessModifier.Source = Source;
        }

        public IFieldAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            Source.Generator.AddGenerationData(typeof(IFieldAccessSpecifier<>), accessSpecifier);
            return _fieldAccessModifier;
        }
    }

    public class FieldAccessModifier<T> : IFieldAccessModifier<T>
        where T : IGeneratedObject
    {
        private readonly IFieldType<T> _fieldType;
        public T Source { get; set; }

        public FieldAccessModifier(IFieldType<T> fieldType)
        {
            _fieldType = fieldType;
            _fieldType.Source = Source;
        }

        public IFieldType<T> WithAccessModifier(AccessModifiers accessModifiers)
        {
            Source.Generator.AddGenerationData(typeof(FieldAccessModifier<>), accessModifiers);
            return _fieldType;
        }
    }

    public class FieldType<T> : IFieldType<T>
        where T : IGeneratedObject
    {
        private readonly IFieldName<T> _fieldName;
        public T Source { get; set; }

        public FieldType(IFieldName<T> fieldName)
        {
            _fieldName = fieldName;
            _fieldName.Source = Source;
        }

        public IFieldName<T> WithType(Type type)
        {
            Source.Generator.AddGenerationData(typeof(FieldType<>), type);
            return _fieldName;
        }
    }

    public class FieldName<T> : IFieldName<T>
        where T : IGeneratedObject
    {
        private readonly IFieldAttribute<T> _fieldAttribute;
        public T Source { get; set; }

        public FieldName(IFieldAttribute<T> fieldAttribute)
        {
            _fieldAttribute = fieldAttribute;
            _fieldAttribute.Source = Source;
        }

        public IFieldAttribute<T> WithName(string name)
        {
            Source.Generator.AddGenerationData(typeof(FieldName<>), name);
            return _fieldAttribute;
        }
    }

    public class FieldAttribute<T> : IFieldAttribute<T>
        where T : IGeneratedObject
    {
        private readonly IFieldValue<T> _fieldValue;
        public T Source { get; set; }

        public FieldAttribute(IFieldValue<T> fieldValue)
        {
            _fieldValue = fieldValue;
            _fieldValue.Source = Source;
        }

        public IFieldValue<T> WithAttributes(params Type[] attributeTypes)
        {
            Source.Generator.AddGenerationData(typeof(FieldAttribute<>), attributeTypes);
            return _fieldValue;
        }
    }

    public class FieldValue<T> : IFieldValue<T>
        where T : IGeneratedObject
    {
        public T Source { get; set; }

        public T WithNoValue()
        {
            return Source;
        }

        public T WithValue(object value)
        {
            Source.Generator.AddGenerationData(typeof(FieldValue<>), value);
            return Source;
        }
    }

    #endregion

    #region Property interfaces

    public interface IPropertyAccessSpecifier<out T>
    {
        IPropertyAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }

    public interface IPropertyAccessModifier<out T>
    {
        IPropertyType<T> WithAccessModifier(AccessModifiers accessModifier);
    }

    public interface IPropertyType<out T>
    {
        IPropertyName<T> WithType(Type type);
    }

    public interface IPropertyName<out T>
    {
        IPropertyAttribute<T> WithName(string name);
    }

    public interface IPropertyAttribute<out T>
    {
        IGetAccessSpecifier<T> WithAttributes(params Type[] attributeType);
    }

    public interface IGetAccessSpecifier<out T>
    {
        IGetBody<T> WithGetAccessSpecifier(AccessSpecifier accessSpecifier);
    }

    public interface IGetBody<out T>
    {
        ISetAccessSpecifier<T> AutoGet();
        ISetAccessSpecifier<T> WithGetBody(string body);
    }

    public interface ISetAccessSpecifier<out T>
    {
        ISetBody<T> WithSetAccessSpecifier(AccessSpecifier accessSpecifier);
    }

    public interface ISetBody<out T>
    {
        IPropertyValue<T> AutoSet();
        IPropertyValue<T> WithSetBody(string body);
    }

    public interface IPropertyValue<out T>
    {
        T WithNoValue();
        T WithPropertyValue(string value);
    }

    public interface IProperty<out T> : IGeneratedObject, IEndable<T>,
        IPropertyAccessSpecifier<IProperty<T>>, IPropertyAccessModifier<IProperty<T>>,
        IPropertyType<IProperty<T>>, IPropertyName<IProperty<T>>, IPropertyAttribute<IProperty<T>>,
        IGetBody<IProperty<T>>, ISetBody<IProperty<T>>, IPropertyValue<IProperty<T>>
    {

    }

    #endregion

    #region Method interfaces

    public interface IMethodAccessSpecifier<out T>
    {
        IMethodAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }

    public interface IMethodAccessModifier<out T>
    {
        IMethodType<T> WithAccessModifier(AccessModifiers accessModifier);
    }

    public interface IMethodType<out T>
    {
        IMethodName<T> WithType(Type type);
    }

    public interface IMethodName<out T>
    {
        IMethodAttribute<T> WithName(string name);
    }

    public interface IMethodAttribute<out T>
    {
        IMethodParameters<T> WithAttributes(params Type[] attributeType);
    }

    public interface IMethodParameters<out T>
    {
        IMethodBody<T> WithParameters(params IParameter[] parameterType);
    }

    public interface IMethodBody<out T>
    {
        T WithMethodBody(string body);
    }

    public interface IMethod<out T> : IGeneratedObject, IEndable<T>,
        IMethodAccessSpecifier<IMethod<T>>, IMethodAccessModifier<IMethod<T>>, IMethodType<IMethod<T>>,
        IMethodName<IMethod<T>>, IMethodAttribute<IMethod<T>>, IMethodParameters<IMethod<T>>,
        IMethodBody<IMethod<T>>
    {

    }

    #endregion

    #region Generators

    public interface IGenerator
    {
        string Generate(string pattern);
        void AddGenerationData(Type type, object data);
    }

    #endregion

    #region IGeneratableHandler

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

    public interface IGeneratableHandler
    {
        string Generate(GenerationData data);
    }

    public class AccessSpecifierGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<AccessSpecifier, string> SpecifiersMap =
            new Dictionary<AccessSpecifier, string>
            {
                [AccessSpecifier.None] = string.Empty,
                [AccessSpecifier.Private] = "private",
                [AccessSpecifier.Protected] = "protected",
                [AccessSpecifier.ProtectedInternal] = "protected internal",
                [AccessSpecifier.Internal] = "internal",
                [AccessSpecifier.Public] = "public"
            };

        public string Generate(GenerationData data)
        {
            var accessSpecifier = (AccessSpecifier)data.Data;
            return SpecifiersMap[accessSpecifier];
        }
    }

    public class AccessModifierGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<string, string> ModifiersMap =
            new Dictionary<string, string>
            {
                [AccessModifiers.None.ToString()] = string.Empty,
                [AccessModifiers.Const.ToString()] = "const",
                [AccessModifiers.Readonly.ToString()] = "readonly",
                [AccessModifiers.Static.ToString()] = "static",
                [AccessModifiers.Volatile.ToString()] = "volatile",
            };

        public string Generate(GenerationData data)
        {
            var accessModifiers = ((AccessModifiers)data.Data).ToString().Replace(",", string.Empty).Split(' ');
            var outputCode = string.Empty;
            outputCode = accessModifiers.Aggregate(outputCode, (current, modifier) => current + ModifiersMap[modifier]);
            return outputCode;
        }
    }

    public class TypeGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            return data.Type.AssemblyQualifiedName;
        }
    }

    public class NameGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            return (string)data.Data;
        }
    }

    public class ValueGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data.Data == null)
            {
                return "null";
            }

            return data.Data.ToString();
        }
    }

    public class AttributeGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data.Data == null)
            {
                return string.Empty;
            }

            return data.Data.ToString();
        }
    }

    #endregion

    public interface IClass : IStorageContainer<IClass>, IFluentContainer<IClass>, IGeneratedObject
    {
        void Build();
    }

    public interface IInterface : IStorageContainer<IInterface>, IFluentContainer<IInterface>, IGeneratedObject
    {
        void Build();
    }

    public class Class : IClass
    {
        private readonly IFactory<IField<IClass>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; }

        private List<IField<IClass>> _fields;
        private List<IProperty<IClass>> _properties;
        private List<IMethod<IClass>> _methods;

        public Class(IGenerator codeGenerator, IFactory<IField<IClass>> factory)
        {
            _factory = factory;
            Generator = codeGenerator;
        }

        public IField<IClass> WithField()
        {
            var instance = _factory.Create(typeof(IField<IClass>));
            instance.Source = this;
            return instance;
        }

        public IProperty<IClass> WithProperty()
        {
            throw new NotImplementedException();
        }

        public IMethod<IClass> WithMethod()
        {
            throw new NotImplementedException();
        }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public void AddField(IField<IClass> field)
        {
            _fields.Add(field);
        }

        public void AddProperty(IProperty<IClass> property)
        {
            _properties.Add(property);
        }

        public void AddMethod(IMethod<IClass> method)
        {
            _methods.Add(method);
        }
    }
}




































#region General

//public interface IAccessSpecifier<out T>
//{
//    T WithAccessSpecifier(AccessSpecifier accessSpecifier);
//}

//public interface IAccessModifier<out T>
//{
//    T WithAccessModifier(AccessModifiers accessModifier);
//}

//public interface IType<out T>
//{
//    T WithType(Type type);
//}

//public interface IName<out T>
//{
//    T WithName(string name);
//}

//public interface IAttribute<out T>
//{
//    T WithAttributes(params Type[] attributeType);
//}

////public interface IField<T> : IAccessSpecifier<IAccessModifier<IType<IName<IAttribute<IField<T>>>>>>, IBuildable<T>
////{

////}

#endregion
