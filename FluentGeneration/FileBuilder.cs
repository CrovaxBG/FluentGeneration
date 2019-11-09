﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
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
using FluentGeneration.Implementations.File;
using FluentGeneration.Implementations.Interface;
using FluentGeneration.Implementations.Method;
using FluentGeneration.Implementations.Property;
using FluentGeneration.Interfaces.File;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Unity.Injection;
using ClassType = FluentGeneration.Implementations.Class.ClassType;

namespace FluentGeneration
{
    public class FileBuilder
    {
        private const string MissingUsingDirectiveErrorId = "CS0246";

        private readonly IDependencyResolver _dependencyResolver;
        private readonly List<IFile> _files = new List<IFile>();

        public FileBuilder()
        {
            var patternContainer = SetupPatternContainer();
            var patternResolver = new PatternResolver(patternContainer);

            var diContainer = SetupDIContainer(patternContainer, patternResolver);
            _dependencyResolver = new UnityResolver(diContainer);
        }

        public FileBuilder(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
        }

        public IFile DefineFile()
        {
            var file = _dependencyResolver.Resolve<IFile>();
            file.Source = () => this;
            return file;
        }

        public void Build()
        {
            foreach (var file in _files)
            {
                FileHelper.CreateFile(file);
            }
        }

        public FileBuilder AddFile(IFile file)
        {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            _files.Add(file);
            return this;
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
            RegisterFileDependencies(container);

            return container;
        }

        private void RegisterFileDependencies(IUnityContainer container)
        {
            container.RegisterType<IFilePath, FilePath>();
            container.RegisterType<IFileName, FileName>();
            container.RegisterType<IFileBody, FileBody>(
                new InjectionConstructor(
                    new ResolvedParameter<IGenerator>("MultipleValue"),
                    new ResolvedParameter<IFactory<IFluentLink<IFileBody>>>()));
            container.RegisterType<IFile, File>();
        }

        private void RegisterInterfaceDependencies(IUnityContainer container)
        {
            container.RegisterType<IInterfaceNamespace, InterfaceNamespace>();
            container.RegisterType<IInterfaceUsingDirectives, InterfaceUsingDirectives>();
            container.RegisterType<IInterfaceAccessSpecifier, InterfaceAccessSpecifier>();
            container.RegisterType<IInterfaceName, InterfaceName>();
            container.RegisterType<IInterfaceAttribute, InterfaceAttribute>();
            container.RegisterType<IInterfaceGenericArguments, InterfaceGenericArguments>();
            container.RegisterType<IInterfaceGenericArgumentsConstraints, InterfaceGenericArgumentsConstraints>();
            container.RegisterType<IInterfaceInheritance, InterfaceInheritance>();
            container.RegisterType<IInterfaceBody, InterfaceBody>(
                new InjectionConstructor(
                    new ResolvedParameter<IGenerator>("MultipleValue"),
                    new ResolvedParameter<IFactory<IFluentLink<IInterfaceBody>>>()));
            container.RegisterType<IInterface, Interface>();
        }

        private void RegisterClassDependencies(IUnityContainer container)
        {
            container.RegisterType<IClassNamespace, ClassNamespace>();
            container.RegisterType<IClassUsingDirectives, ClassUsingDirectives>();
            container.RegisterType<IClassAccessSpecifier, ClassAccessSpecifier>();
            container.RegisterType<IClassType, ClassType>();
            container.RegisterType<IClassName, ClassName>();
            container.RegisterType<IClassAttribute, ClassAttribute>();
            container.RegisterType<IClassGenericArguments, ClassGenericArguments>();
            container.RegisterType<IClassGenericArgumentsConstraints, ClassGenericArgumentsConstraints>();
            container.RegisterType<IClassInheritance, ClassInheritance>();
            container.RegisterType<IClassBody, ClassBody>(
                new InjectionConstructor(
                    new ResolvedParameter<IGenerator>("MultipleValue"),
                    new ResolvedParameter<IFactory<IFluentLink<IClassBody>>>()));
            container.RegisterType<IClass, Class>();
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
            container.RegisterType(typeof(IFieldAccessSpecifier), typeof(FieldAccessSpecifier));
            container.RegisterType(typeof(IFieldAccessModifier), typeof(FieldAccessModifier));
            container.RegisterType(typeof(IFieldType), typeof(FieldType));
            container.RegisterType(typeof(IFieldName), typeof(FieldName));
            container.RegisterType(typeof(IFieldAttribute), typeof(FieldAttribute));
            container.RegisterType(typeof(IFieldValue), typeof(FieldValue));
            container.RegisterType(typeof(IField), typeof(Field));
        }

        private IPatternContainer SetupPatternContainer()
        {
            var container = new PatternContainer();

            RegisterFieldPatternGenerators(container);
            RegisterPropertyPatternGenerators(container);
            RegisterMethodPatternGenerators(container);
            RegisterClassPatternGenerators(container);
            RegisterInterfacePatternGenerators(container);
            RegisterFilePatternGenerators(container);

            return container;
        }

        private void RegisterFilePatternGenerators(IPatternContainer container)
        {
            container.RegisterType<IInterface, RawStringDataGenerator>();
            container.RegisterType<IClass, RawStringDataGenerator>();
        }

        private void RegisterInterfacePatternGenerators(IPatternContainer container)
        {
            container.RegisterType<IInterfaceNamespace, NamespaceGenerator>();
            container.RegisterType<IInterfaceUsingDirectives, UsingDirectivesGenerator>();
            container.RegisterType<IInterfaceAccessSpecifier, AccessSpecifierGenerator>();
            container.RegisterType<IInterfaceName, NameGenerator>();
            container.RegisterType<IInterfaceAttribute, AttributeGenerator>();
            container.RegisterType<IInterfaceGenericArguments, GenericArgumentsGenerator>();
            container.RegisterType<IInterfaceGenericArgumentsConstraints, GenericArgumentsConstraintsGenerator>();
            container.RegisterType<IInterfaceInheritance, InheritanceGenerator>();
            container.RegisterType<IInterfaceBody, RawStringDataGenerator>();
        }

        private void RegisterClassPatternGenerators(IPatternContainer container)
        {
            container.RegisterType<IClassNamespace, NamespaceGenerator>();
            container.RegisterType<IClassUsingDirectives, UsingDirectivesGenerator>();
            container.RegisterType<IClassAccessSpecifier, AccessSpecifierGenerator>();
            container.RegisterType<IClassType, ClassTypeGenerator>();
            container.RegisterType<IClassName, NameGenerator>();
            container.RegisterType<IClassAttribute, AttributeGenerator>();
            container.RegisterType<IClassGenericArguments, GenericArgumentsGenerator>();
            container.RegisterType<IClassGenericArgumentsConstraints, GenericArgumentsConstraintsGenerator>();
            container.RegisterType<IClassInheritance, InheritanceGenerator>();
            container.RegisterType<IClassBody, RawStringDataGenerator>();
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
            container.RegisterType(typeof(IFieldAccessSpecifier), typeof(AccessSpecifierGenerator));
            container.RegisterType(typeof(IFieldAccessModifier), typeof(AccessModifierGenerator));
            container.RegisterType(typeof(IFieldType), typeof(TypeGenerator));
            container.RegisterType(typeof(IFieldName), typeof(NameGenerator));
            container.RegisterType(typeof(IFieldAttribute), typeof(AttributeGenerator));
            container.RegisterType(typeof(IFieldValue), typeof(ValueGenerator));
        }

        #endregion
    }
}