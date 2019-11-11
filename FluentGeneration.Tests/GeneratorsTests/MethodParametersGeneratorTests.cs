using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class MethodParametersGeneratorTests
    {
        [Test]
        public void MultipleParametersHalfAttributesTest()
        {
            var generator = new MethodParametersGenerator();

            var parameters = new[]
            {
                Parameter.Standard(typeof(System.Int32), "a", typeof(System.ObsoleteAttribute)),
                Parameter.Standard(typeof(System.String), "b"),
            };
            var result = generator.Generate(parameters);

            Assert.AreEqual("[System.ObsoleteAttribute] System.Int32 a, System.String b", result);
        }

        [Test]
        public void MultipleParametersTest()
        {
            var generator = new MethodParametersGenerator();

            var parameters = new[]
            {
                Parameter.Standard(typeof(System.Int32), "a", typeof(System.ObsoleteAttribute)),
                Parameter.Standard(typeof(System.String), "b", typeof(System.ObsoleteAttribute)),
            };
            var result = generator.Generate(parameters);

            Assert.AreEqual("[System.ObsoleteAttribute] System.Int32 a, [System.ObsoleteAttribute] System.String b", result);
        }

        [Test]
        public void SingleParameterTest()
        {
            var generator = new MethodParametersGenerator();

            var parameters = new[] {Parameter.Standard(typeof(System.Int32), "a", typeof(System.ObsoleteAttribute)),};
            var result = generator.Generate(parameters);

            Assert.AreEqual("[System.ObsoleteAttribute] System.Int32 a", result);
        }

        [Test]
        public void EmptyDataTest()
        {
            var generator = new MethodParametersGenerator();
            var result = generator.Generate(new IParameter[0]);

            Assert.AreEqual("", result);
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(@"IEnumerable<T1> a", ExpectedResult = @"IEnumerable<T1> a")]
        public string LiteralDataTest(string data)
        {
            var generator = new MethodParametersGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new MethodParametersGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new MethodParametersGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}