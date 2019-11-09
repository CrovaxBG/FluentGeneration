using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using FluentGeneration;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGenerationExecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\")) + @"\TestFiles\";
            Stopwatch sw = Stopwatch.StartNew();
            TestSingleInterfaceWithMultiple(path);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }

        private static void TestSingleClassWithMultiple(string path)
        {
            new FileBuilder()
                .DefineFile()
                    .Begin().WithPath(path).WithName("BasicClass")
                        .WithClass()
                        .Begin()
                            .WithNamespace("first").WithUsingDirectives()
                            .WithAccessSpecifier(AccessSpecifier.None).WithClassType(ClassType.Standard).WithName("BasicClass").WithAttributes()
                            .WithGenericArguments().WithGenericArgumentConstraint().WithInheritance()
                            .WithFields(FieldSequenceGenerator)
                            .WithProperties(ClassPropertySequenceGenerator)
                            .WithMethods(ClassMethodSequenceGenerator)
                        .End()
                    .End()
                .End()
            .End()
            .Build();
        }

        private static void TestSingleInterfaceWithMultiple(string path)
        {
            new FileBuilder()
                .DefineFile()
                    .Begin().WithPath(path).WithName("IBasicInterface")
                        .WithInterface()
                        .Begin()
                            .WithNamespace("first").WithUsingDirectives()
                            .WithAccessSpecifier(AccessSpecifier.None).WithName("IBasicInterface").WithAttributes()
                            .WithGenericArguments().WithGenericArgumentConstraint().WithInheritance()
                            .WithProperties(InterfacePropertySequenceGenerator)
                            .WithMethods(InterfaceMethodSequenceGenerator)
                        .End()
                    .End()
                .End()
            .End()
            .Build();
        }

        private static IEnumerable<IMethod<IInterfaceBody>> InterfaceMethodSequenceGenerator(Func<IMethod<IInterfaceBody>> value)
        {
            return Enumerable.Range(0, 101).Select(i => value.Invoke().Begin()
                .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None)
                .WithType(typeof(string)).WithName($"Method_{i}").WithAttributes(typeof(PureAttribute))
                .WithGenericArguments().WithGenericArgumentConstraint()
                .WithParameters(Parameter.Standard(typeof(IParameter), "parameter"))
                .WithEmptyBody());
        }

        private static IEnumerable<IProperty<IInterfaceBody>> InterfacePropertySequenceGenerator(Func<IProperty<IInterfaceBody>> value)
        {
            return Enumerable.Range(0, 101).Select(i => value.Invoke().Begin()
                .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None)
                .WithType(typeof(int)).WithName($"Property_{i}").WithAttributes()
                .WithGetAccessSpecifier(AccessSpecifier.None).AutoGet()
                .WithSetAccessSpecifier(AccessSpecifier.None).AutoSet()
                .WithNoValue());
        }

        private static IEnumerable<IMethod<IClassBody>> ClassMethodSequenceGenerator(Func<IMethod<IClassBody>> value)
        {
            return Enumerable.Range(0, 101).Select(i => value.Invoke().Begin()
                .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                .WithType(typeof(string)).WithName($"Method_{i}").WithAttributes(typeof(PureAttribute))
                .WithGenericArguments().WithGenericArgumentConstraint()
                .WithParameters(Parameter.Standard(typeof(IParameter), "parameter"))
                .WithMethodBody($@"return {i}.ToString();"));
        }

        private static IEnumerable<IProperty<IClassBody>> ClassPropertySequenceGenerator(Func<IProperty<IClassBody>> value)
        {
            return Enumerable.Range(0, 101).Select(i => value.Invoke().Begin()
                .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                .WithType(typeof(int)).WithName($"Property_{i}").WithAttributes()
                .WithGetAccessSpecifier(AccessSpecifier.None).AutoGet()
                .WithSetAccessSpecifier(AccessSpecifier.None).AutoSet()
                .WithNoValue());
        }

        private static IEnumerable<IField> FieldSequenceGenerator(Func<IField> value)
        {
            return Enumerable.Range(0, 101).Select(i => value.Invoke().Begin()
                .WithAccessSpecifier(AccessSpecifier.Private)
                .WithAccessModifier(AccessModifiers.Readonly)
                .WithType(typeof(int)).WithName($"_field_{i}")
                .WithAttributes()
                .WithValue(i));
        }

        private static void TestAll(string path)
        {
            new FileBuilder()
                .DefineFile()
                    .Begin().WithPath(path).WithName("BasicClass")
                        .WithClass()
                            .Begin()
                                .WithNamespace("first").WithUsingDirectives()
                                .WithAccessSpecifier(AccessSpecifier.None).WithClassType(ClassType.Standard).WithName("BasicClass").WithAttributes()
                                .WithGenericArguments().WithGenericArgumentConstraint().WithInheritance()
                            .End()
                        .End()
                    .End()
                .End()
                .DefineFile()
                .Begin().WithPath(path).WithName("AdvancedClass")
                    .WithClass()
                        .Begin()
                            .WithNamespace("first.second").WithUsingDirectives()
                            .WithAccessSpecifier(AccessSpecifier.Public).WithClassType(ClassType.Abstract)
                            .WithName("AdvancedClass").WithAttributes(@"[System.Obsolete(""use something else"")]")
                            .WithGenericArguments(
                                new GenericArgument { Name = "T1" },
                                new GenericArgument { Name = "T2" },
                                new GenericArgument { Name = "T3" })
                            .WithGenericArgumentConstraint(
                                new GenericArgumentConstraint { GenericArgumentName = "T1", Constraints = new[] { typeof(IComparable) } },
                                new GenericArgumentConstraint { GenericArgumentName = "T2", Constraints = new[] { typeof(IComparable) } })
                            .WithInheritance("IEnumerable<T1>")
                            .WithMethod()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None).WithType("IEnumerator<T1>")
                                    .WithName("GetEnumerator").WithAttributes().WithGenericArguments().WithGenericArgumentConstraint()
                                    .WithParameters().WithMethodBody("throw new NotImplementedException();")
                                .End()
                            .WithMethod()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None).WithType("IEnumerator")
                                    .WithName("IEnumerable.GetEnumerator").WithAttributes().WithGenericArguments().WithGenericArgumentConstraint()
                                    .WithParameters().WithMethodBody("return GetEnumerator();")
                                .End()
                            .End()
                        .End()
                    .End()
                .End()
                .DefineFile()
                .Begin().WithPath(path).WithName("FullClass")
                    .WithClass()
                        .Begin()
                        .WithNamespace("first.second.third").WithUsingDirectives()
                        .WithAccessSpecifier(AccessSpecifier.Public).WithClassType(ClassType.Standard).WithName("FullClass")
                        .WithAttributes().WithGenericArguments(new GenericArgument { Name = "T" }).WithGenericArgumentConstraint().WithInheritance()
                            .WithField()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Private).WithAccessModifier(AccessModifiers.Static | AccessModifiers.Readonly)
                                    .WithType(typeof(int)).WithName("_count").WithAttributes(typeof(RequiredAttribute), typeof(DisplayAttribute))
                                    .WithNoValue()
                                .End()
                            .WithField()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Private).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(List<string>)).WithName("_counters").WithAttributes(typeof(RequiredAttribute), typeof(DisplayAttribute))
                                    .WithNoValue()
                                .End()
                            .WithProperty()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(List<string>)).WithName("Counters").WithAttributes(typeof(RequiredAttribute))
                                    .WithGetAccessSpecifier(AccessSpecifier.None).WithGetBody("return _counters;")
                                    .WithSetAccessSpecifier(AccessSpecifier.Private).WithSetBody("_counters = value;")
                                    .WithNoValue()
                                .End()
                            .WithProperty()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(string)).WithName("AutoProp").WithAttributes(typeof(RequiredAttribute))
                                    .WithGetAccessSpecifier(AccessSpecifier.None).AutoGet()
                                    .WithSetAccessSpecifier(AccessSpecifier.None).AutoSet()
                                    .WithPropertyValue(null)
                                .End()
                            .WithMethod()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.Static)
                                    .WithType(typeof(void)).WithName("Method1").WithAttributes().WithGenericArguments().WithGenericArgumentConstraint()
                                    .WithParameters(Parameter.Standard(typeof(int), "x"), Parameter.Ref(typeof(int), "y"), Parameter.Out(typeof(int), "z"))
                                    .WithMethodBody("z = x + y;")
                                .End()
                            .WithMethod()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(string)).WithName("Method2").WithAttributes(typeof(PureAttribute))
                                    .WithGenericArguments().WithGenericArgumentConstraint()
                                    .WithParameters(Parameter.Standard(typeof(IParameter), "parameter"))
                                    .WithMethodBody(@"return string.Empty;")
                                .End()
                            .End()
                        .End()
                    .End()
                .End()
                .DefineFile()
                    .Begin().WithPath(path).WithName("IBasicInterface")
                .WithInterface()
                        .Begin()
                            .WithNamespace("first").WithUsingDirectives()
                            .WithAccessSpecifier(AccessSpecifier.None).WithName("IBasicInterface").WithAttributes()
                            .WithGenericArguments().WithGenericArgumentConstraint().WithInheritance()
                            .End()
                        .End()
                    .End()
                .End()
                .DefineFile()
                    .Begin().WithPath(path).WithName("IAdvancedInterface")
                    .WithInterface()
                        .Begin()
                            .WithNamespace("first.second").WithUsingDirectives()
                            .WithAccessSpecifier(AccessSpecifier.Public).WithName("IAdvancedInterface").WithAttributes(@"[System.Obsolete(""use something else"")]")
                            .WithGenericArguments(
                                new GenericArgument { Name = "T1" },
                                new GenericArgument { Name = "T2", Type = GenericArgumentType.Covariant },
                                new GenericArgument { Name = "T3", Type = GenericArgumentType.Contravariant })
                            .WithGenericArgumentConstraint(
                                new GenericArgumentConstraint { GenericArgumentName = "T1", Constraints = new[] { typeof(IComparable) } },
                                new GenericArgumentConstraint { GenericArgumentName = "T2", Constraints = new[] { typeof(IComparable) } })
                            .WithInheritance("IEnumerable<T1>")
                            .End()
                        .End()
                    .End()
                .End()
                .DefineFile()
                    .Begin().WithPath(path).WithName("IFullInterface")
                    .WithInterface()
                        .Begin()
                            .WithNamespace("first.second.third").WithUsingDirectives()
                            .WithAccessSpecifier(AccessSpecifier.Public).WithName("IFullInterface").WithAttributes()
                            .WithGenericArguments(new GenericArgument { Name = "T1" }).WithGenericArgumentConstraint().WithInheritance()
                            .WithMethod()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(void)).WithName("VoidMethod").WithAttributes().WithGenericArguments(new GenericArgument { Name = "T" })
                                    .WithGenericArgumentConstraint().WithParameters().WithEmptyBody()
                                .End()
                            .WithMethod()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(void)).WithName("VoidMethod2").WithAttributes().WithGenericArguments()
                                    .WithGenericArgumentConstraint().WithParameters(Parameter.Standard(typeof(int), "intParam")).WithEmptyBody()
                                .End()
                            .WithProperty()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(string)).WithName("StringProperty").WithAttributes()
                                    .WithGetAccessSpecifier(AccessSpecifier.None).AutoGet().WithSetAccessSpecifier(AccessSpecifier.None)
                                    .AutoSet().WithNoValue()
                                .End()
                            .WithProperty()
                                .Begin()
                                    .WithAccessSpecifier(AccessSpecifier.None).WithAccessModifier(AccessModifiers.None)
                                    .WithType(typeof(Dictionary<HashSet<int>, List<int>>)).WithName("MapProp").WithAttributes(typeof(RequiredAttribute))
                                    .WithGetAccessSpecifier(AccessSpecifier.None).AutoGet().WithSetAccessSpecifier(AccessSpecifier.None)
                                    .NoSet().WithNoValue()
                                .End()
                            .End()
                        .End()
                    .End()
                .End()
                .Build();
        }
    }
}
