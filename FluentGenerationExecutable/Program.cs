using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using FluentGeneration;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;
using Unity;

namespace FluentGenerationExecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            new GenerationBuilder()
                .DefineClass()
                    .Begin()
                        .WithAccessSpecifier(AccessSpecifier.Public).WithClassType(ClassType.Abstract)
                        .WithClassName("EmptyAbstractClassTest").WithClassAttributes()
                        .WithGenericArguments(new GenericArgument{Name = "T1"}, new GenericArgument{Name = "T2"})
                        .WithGenericArgumentConstraint(new GenericArgumentConstraint{GenericArgumentName = "T1", Constraints = new []{typeof(IComparable)}})
                        .WithClassInheritance("IEnumerable<T1>")
                    .End()
                .End();
            Console.ReadKey();
            new GenerationBuilder()
                .DefineClass()
                    .Begin()
                    .WithAccessSpecifier(AccessSpecifier.None).WithClassType(ClassType.Standard).WithClassName("qwe")
                    .WithClassAttributes().WithGenericArguments().WithGenericArgumentConstraint().WithClassInheritance()
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
                                .WithParameters(Parameter.Standard(typeof(IParameter),"parameter"))
                                .WithMethodBody(@"var attributes = string.Join(string.Empty,
            parameter.ParameterAttributes.Select(att => att.FormatTypeName()));
            var modifier = ModifierMap[parameter.ParameterModifier];
            var type = parameter.ParameterType.FormatTypeName();
            var name = parameter.ParameterName;
            var sections = new[] {attributes, modifier, type, name};
            var output = sections.Where(section => !string.IsNullOrEmpty(section))
                .Aggregate(string.Empty, (current, section) => current + section + "" "");
            return output.TrimEnd(' ');")
                            .End()
                        .WithMethod()
                            .Begin()
                                .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                                .WithType(typeof(void)).WithName("MethodSignature").WithAttributes()
                                .WithGenericArguments(new GenericArgument{Name = "T"}).WithGenericArgumentConstraint()
                                .WithParameters()
                                .WithEmptyBody()
                            .End()
                        .WithMethod()
                            .Begin()
                                .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                                .WithType(typeof(void)).WithName("MethodSignature").WithAttributes()
                                .WithGenericArguments(new GenericArgument{Name = "T"})
                                .WithGenericArgumentConstraint(new GenericArgumentConstraint{GenericArgumentName = "T", Constraints = new []{typeof(IComparable)}})
                                .WithParameters()
                                .WithEmptyBody()
                            .End()
                        .End()
                    .End();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
