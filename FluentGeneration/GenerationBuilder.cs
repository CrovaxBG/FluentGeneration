using Unity;
using Unity.Lifetime;
using FluentGeneration.Factories;
using FluentGeneration.Resolvers;
using FluentGeneration.Containers;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Implementations.Class;
using FluentGeneration.Implementations.Field;
using FluentGeneration.Implementations.Interface;
using FluentGeneration.Implementations.Method;
using FluentGeneration.Implementations.Property;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using Unity.Injection;

namespace FluentGeneration
{
    public class GenerationBuilder
    {
        private readonly IDependencyResolver _dependencyResolver;

        public GenerationBuilder()
        {
            var patternContainer = SetupPatternContainer();
            var patternResolver = new PatternResolver(patternContainer);

            var diContainer = SetupDIContainer(patternContainer, patternResolver);
            _dependencyResolver = new UnityResolver(diContainer);
        }

        public GenerationBuilder(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        #region Setup Resolvers

        private IUnityContainer SetupDIContainer(IPatternContainer patternContainer, IPatternResolver patternResolver)
        {
            var container = new UnityContainer();

            container.RegisterInstance(typeof(IPatternContainer), patternContainer,
                new ContainerControlledLifetimeManager());
            container.RegisterInstance(typeof(IPatternResolver), patternResolver,
                new ContainerControlledLifetimeManager());

            container.RegisterType(typeof(IFactory<>), typeof(AbstractFactory<>));
            container.RegisterType(typeof(IFactory<IGeneratableHandler>), typeof(PatternFactory));

            container.RegisterType(typeof(IGenerator), typeof(SingleValueCodeGenerator));
            container.RegisterType(typeof(IGenerator), typeof(MultipleValueGenerator), "MultipleValue");

            RegisterFieldDependencies(container);
            RegisterPropertyDependencies(container);
            RegisterMethodDependencies(container);
            RegisterClassDependencies(container);
            RegisterInterfaceDependencies(container);

            return container;
        }

        private void RegisterInterfaceDependencies(IUnityContainer container)
        {
            container.RegisterType(typeof(IInterfaceAccessSpecifier<>), typeof(InterfaceAccessSpecifier<>));
            container.RegisterType(typeof(IInterfaceName<>), typeof(InterfaceName<>));
            container.RegisterType(typeof(IInterfaceAttribute<>), typeof(InterfaceAttribute<>));
            container.RegisterType(typeof(IInterfaceGenericArguments<>), typeof(InterfaceGenericArguments<>));
            container.RegisterType(typeof(IInterfaceGenericArgumentsConstraints<>),
                typeof(InterfaceGenericArgumentsConstraints<>));
            container.RegisterType(typeof(IInterfaceInheritance<>), typeof(InterfaceInheritance<>));
            container.RegisterType(typeof(IInterfaceBody<>), typeof(InterfaceBody<>),
                new InjectionConstructor(new ResolvedParameter<IGenerator>("MultipleValue"),
                    new ResolvedParameter(typeof(IFactory<>))));
            container.RegisterType(typeof(IInterface), typeof(Interface));
        }

        private void RegisterClassDependencies(IUnityContainer container)
        {
            container.RegisterType(typeof(IClassAccessSpecifier<>), typeof(ClassAccessSpecifier<>));
            container.RegisterType(typeof(IClassType<>), typeof(ClassType<>));
            container.RegisterType(typeof(IClassName<>), typeof(ClassName<>));
            container.RegisterType(typeof(IClassAttribute<>), typeof(ClassAttribute<>));
            container.RegisterType(typeof(IClassGenericArguments<>), typeof(ClassGenericArguments<>));
            container.RegisterType(typeof(IClassGenericArgumentsConstraints<>), typeof(ClassGenericArgumentsConstraints<>));
            container.RegisterType(typeof(IClassInheritance<>), typeof(ClassInheritance<>));
            container.RegisterType(typeof(IClassBody<>), typeof(ClassBody<>),
                new InjectionConstructor(new ResolvedParameter<IGenerator>("MultipleValue"),
                    new ResolvedParameter(typeof(IFactory<>))));
            container.RegisterType(typeof(IClass), typeof(Class));
        }

        private void RegisterMethodDependencies(IUnityContainer container)
        {
            container.RegisterType(typeof(IMethodAccessSpecifier<>), typeof(MethodAccessSpecifier<>));
            container.RegisterType(typeof(IMethodAccessModifier<>), typeof(MethodAccessModifier<>));
            container.RegisterType(typeof(IMethodType<>), typeof(MethodType<>));
            container.RegisterType(typeof(IMethodName<>), typeof(MethodName<>));
            container.RegisterType(typeof(IMethodGenericArguments<>), typeof(MethodGenericArguments<>));
            container.RegisterType(typeof(IMethodGenericArgumentsConstraints<>), typeof(MethodGenericArgumentsConstraints<>));
            container.RegisterType(typeof(IMethodAttribute<>), typeof(MethodAttribute<>));
            container.RegisterType(typeof(IMethodParameters<>), typeof(MethodParameters<>));
            container.RegisterType(typeof(IMethodBody<>), typeof(MethodBody<>));
            container.RegisterType(typeof(IMethod<>), typeof(Method<>));
        }

        private void RegisterPropertyDependencies(IUnityContainer container)
        {
            container.RegisterType(typeof(IPropertyAccessSpecifier<>), typeof(PropertyAccessSpecifier<>));
            container.RegisterType(typeof(IPropertyAccessModifier<>), typeof(PropertyAccessModifier<>));
            container.RegisterType(typeof(IPropertyType<>), typeof(PropertyType<>));
            container.RegisterType(typeof(IPropertyName<>), typeof(PropertyName<>));
            container.RegisterType(typeof(IPropertyAttribute<>), typeof(PropertyAttribute<>));
            container.RegisterType(typeof(IGetAccessSpecifier<>), typeof(GetAccessSpecifier<>));
            container.RegisterType(typeof(IGetBody<>), typeof(GetBody<>));
            container.RegisterType(typeof(ISetAccessSpecifier<>), typeof(SetAccessSpecifier<>));
            container.RegisterType(typeof(ISetBody<>), typeof(SetBody<>));
            container.RegisterType(typeof(IPropertyValue<>), typeof(PropertyValue<>));
            container.RegisterType(typeof(IProperty<>), typeof(Property<>));
        }

        private void RegisterFieldDependencies(IUnityContainer container)
        {
            container.RegisterType(typeof(IFieldAccessSpecifier<>), typeof(FieldAccessSpecifier<>));
            container.RegisterType(typeof(IFieldAccessModifier<>), typeof(FieldAccessModifier<>));
            container.RegisterType(typeof(IFieldType<>), typeof(FieldType<>));
            container.RegisterType(typeof(IFieldName<>), typeof(FieldName<>));
            container.RegisterType(typeof(IFieldAttribute<>), typeof(FieldAttribute<>));
            container.RegisterType(typeof(IFieldValue<>), typeof(FieldValue<>));
            container.RegisterType(typeof(IField<>), typeof(Field<>));
        }

        private IPatternContainer SetupPatternContainer()
        {
            var container = new PatternContainer();

            RegisterFieldPatternGenerators(container);
            RegisterPropertyPatternGenerators(container);
            RegisterMethodPatternGenerators(container);
            RegisterClassPatternGenerators(container);
            RegisterInterfacePatternGenerators(container);

            return container;
        }

        private void RegisterInterfacePatternGenerators(IPatternContainer container)
        {
            container.RegisterType(typeof(IInterfaceAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IInterfaceName<>), typeof(NameGenerator));
            container.RegisterType(typeof(IInterfaceAttribute<>), typeof(AttributeGenerator));
            container.RegisterType(typeof(IInterfaceGenericArguments<>), typeof(GenericArgumentsGenerator));
            container.RegisterType(typeof(IInterfaceGenericArgumentsConstraints<>),
                typeof(GenericArgumentsConstraintsGenerator));
            container.RegisterType(typeof(IInterfaceInheritance<>), typeof(InheritanceGenerator));
            container.RegisterType(typeof(IInterfaceBody<>), typeof(RawStringDataGenerator));
        }

        private void RegisterClassPatternGenerators(IPatternContainer container)
        {
            container.RegisterType(typeof(IClassAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IClassType<>), typeof(ClassTypeGenerator));
            container.RegisterType(typeof(IClassName<>), typeof(NameGenerator));
            container.RegisterType(typeof(IClassAttribute<>), typeof(AttributeGenerator));
            container.RegisterType(typeof(IClassGenericArguments<>), typeof(GenericArgumentsGenerator));
            container.RegisterType(typeof(IClassGenericArgumentsConstraints<>), typeof(GenericArgumentsConstraintsGenerator));
            container.RegisterType(typeof(IClassInheritance<>), typeof(InheritanceGenerator));
            container.RegisterType(typeof(IClassBody<>), typeof(RawStringDataGenerator));
        }

        private void RegisterMethodPatternGenerators(IPatternContainer container)
        {
            container.RegisterType(typeof(IMethodAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IMethodAccessModifier<>), typeof(AccessModifierGenerator));
            container.RegisterType(typeof(IMethodType<>), typeof(TypeGenerator));
            container.RegisterType(typeof(IMethodName<>), typeof(NameGenerator));
            container.RegisterType(typeof(IMethodGenericArguments<>), typeof(GenericArgumentsGenerator));
            container.RegisterType(typeof(IMethodGenericArgumentsConstraints<>), typeof(GenericArgumentsConstraintsGenerator));
            container.RegisterType(typeof(IMethodAttribute<>), typeof(AttributeGenerator));
            container.RegisterType(typeof(IMethodParameters<>), typeof(MethodParametersGenerator));
            container.RegisterType(typeof(IMethodBody<>), typeof(MethodBodyGenerator));
        }

        private void RegisterPropertyPatternGenerators(IPatternContainer container)
        {
            container.RegisterType(typeof(IPropertyAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IPropertyAccessModifier<>), typeof(AccessModifierGenerator));
            container.RegisterType(typeof(IPropertyType<>), typeof(TypeGenerator));
            container.RegisterType(typeof(IPropertyName<>), typeof(NameGenerator));
            container.RegisterType(typeof(IPropertyAttribute<>), typeof(AttributeGenerator));
            container.RegisterType(typeof(IPropertyValue<>), typeof(ValueGenerator));
            container.RegisterType(typeof(IGetAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(ISetAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IGetBody<>), typeof(GetBodyGenerator));
            container.RegisterType(typeof(ISetBody<>), typeof(SetBodyGenerator));
        }

        private void RegisterFieldPatternGenerators(IPatternContainer container)
        {
            container.RegisterType(typeof(IFieldAccessSpecifier<>), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IFieldAccessModifier<>), typeof(AccessModifierGenerator));
            container.RegisterType(typeof(IFieldType<>), typeof(TypeGenerator));
            container.RegisterType(typeof(IFieldName<>), typeof(NameGenerator));
            container.RegisterType(typeof(IFieldAttribute<>), typeof(AttributeGenerator));
            container.RegisterType(typeof(IFieldValue<>), typeof(ValueGenerator));
        }

        #endregion

        public void DefineFile()
        {

        }

        public IClass DefineClass()
        {
            return _dependencyResolver.Resolve<IClass>();
        }

        public IInterface DefineInterface()
        {
            return _dependencyResolver.Resolve<IInterface>();
        }
    }
}
