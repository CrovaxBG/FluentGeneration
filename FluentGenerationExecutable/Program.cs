using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
            new GenerationBuilder().DefineClass()
                .WithField()
                    .Begin()
                        .WithAccessSpecifier(AccessSpecifier.Private).WithAccessModifier(AccessModifiers.Static | AccessModifiers.Readonly)
                        .WithType(typeof(List<string>)).WithName("_count").WithAttributes(typeof(RequiredAttribute), typeof(DisplayAttribute))
                        .WithNoValue()
                    .End()
                .WithProperty()
                    .Begin()
                        .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                        .WithType(typeof(string)).WithName("Count").WithAttributes(typeof(RequiredAttribute))
                        .WithGetAccessSpecifier(AccessSpecifier.None).WithGetBody("return _count;")
                        .WithSetAccessSpecifier(AccessSpecifier.Private).WithSetBody("_count = value;")
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
                        .WithType(typeof(void)).WithName("Method1").WithAttributes()
                        .WithParameters(Parameter.Standard(typeof(int), "x"), Parameter.Ref(typeof(int), "y"), Parameter.Out(typeof(int), "z"))
                        .WithMethodBody("z = x + y;")
                    .End()
                .WithMethod()
                    .Begin()
                        .WithAccessSpecifier(AccessSpecifier.Public).WithAccessModifier(AccessModifiers.None)
                        .WithType(typeof(string)).WithName("Method2").WithAttributes()
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
                        .WithParameters()
                        .WithEmptyBody()
                    .End();
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
