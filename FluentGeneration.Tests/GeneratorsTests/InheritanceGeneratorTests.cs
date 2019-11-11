using System;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class InheritanceGeneratorTests
    {
        [Test]
        public void MultipleTypesTest()
        {
            var generator = new InheritanceGenerator();

            var types = new[] {typeof(System.IComparable), typeof(System.IDisposable)};
            var result = generator.Generate(types);

            Assert.AreEqual("System.IComparable, System.IDisposable", result);
        }

        [Test]
        public void SingleTypeTest()
        {
            var generator = new InheritanceGenerator();

            var types = new[] {typeof(System.IComparable)};
            var result = generator.Generate(types);

            Assert.AreEqual("System.IComparable", result);
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(@"IEnumerable<T1>" , ExpectedResult = @"IEnumerable<T1>")]
        public string LiteralDataTest(string data)
        {
            var generator = new InheritanceGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void EmptyDataTest()
        {
            var generator = new InheritanceGenerator();
            var result = generator.Generate(new Type[0]);

            Assert.AreEqual("", result);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new InheritanceGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new InheritanceGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}