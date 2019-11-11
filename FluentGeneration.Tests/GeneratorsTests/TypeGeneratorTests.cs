using System;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class TypeGeneratorTests
    {
        [Test]
        public void SingleAttributeTypeDataTest()
        {
            var generator = new TypeGenerator();
            var type = typeof(System.IComparable);
            var result = generator.Generate(type);

            Assert.AreEqual("System.IComparable", result);
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(@"System.Collections.Generics.IEnumerable<T1>", ExpectedResult = @"System.Collections.Generics.IEnumerable<T1>")]
        public string LiteralDataTest(string data)
        {
            var generator = new TypeGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new TypeGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new TypeGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}