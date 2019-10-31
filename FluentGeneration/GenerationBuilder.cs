using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentGeneration.Containers;
using FluentGeneration.Factories;
using FluentGeneration.Generators;
using FluentGeneration.Implementations.Class;
using FluentGeneration.Implementations.Field;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Resolvers;
using FluentGeneration.Shared;
using Unity;
using Unity.Lifetime;

namespace FluentGeneration
{
    public class GenerationBuilder
    {
        private readonly IDependencyResolver _dependencyResolver;

        public GenerationBuilder()
            : this(null, null)
        {
        }

        public GenerationBuilder(IDependencyResolver dependencyResolver, IPatternResolver patternResolver)
        {
            _dependencyResolver = dependencyResolver;

            IPatternContainer patternContainer = null;

            if (patternResolver == null)
            {
                patternContainer = SetupPatternContainer();
                patternResolver = new PatternResolver(patternContainer);
            }

            if (_dependencyResolver == null)
            {
                var container = SetupDIContainer(patternContainer, patternResolver);
                _dependencyResolver = new UnityResolver(container);
            }
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
            container.RegisterType(typeof(IGenerator), typeof(CodeGenerator));
            container.RegisterType(typeof(IFieldAccessSpecifier<>), typeof(FieldAccessSpecifier<>));
            container.RegisterType(typeof(IFieldAccessModifier<>), typeof(FieldAccessModifier<>));
            container.RegisterType(typeof(IFieldType<>), typeof(FieldType<>));
            container.RegisterType(typeof(IFieldName<>), typeof(FieldName<>));
            container.RegisterType(typeof(IFieldAttribute<>), typeof(FieldAttribute<>));
            container.RegisterType(typeof(IFieldValue<>), typeof(FieldValue<>));
            container.RegisterType(typeof(IField<>), typeof(Field<>));
            container.RegisterType(typeof(IClass), typeof(Class));

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

        #endregion

        public void DefineFile()
        {

        }

        public IClass DefineClass()
        {
            IClass generatedClass = _dependencyResolver.Resolve<IClass>();
            generatedClass
                .WithField()
                    .Begin()
                        .WithAccessSpecifier(AccessSpecifier.Private).WithAccessModifier(AccessModifiers.Static | AccessModifiers.Readonly)
                        .WithType(typeof(List<string>)).WithName("_count").WithAttributes(typeof(RequiredAttribute), typeof(DisplayAttribute))
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
}
