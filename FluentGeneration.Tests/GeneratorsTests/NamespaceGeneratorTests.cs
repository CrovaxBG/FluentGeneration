using System;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class NamespaceGeneratorTests
    {
        [TestCase("TestName", ExpectedResult = "namespace TestName")]
        [TestCase("Test.Name", ExpectedResult = "namespace Test.Name")]
        public string NameTest(string data)
        {
            var generator = new NamespaceGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void EmptyDataTest()
        {
            var generator = new NamespaceGenerator();

            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(string.Empty));
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new NamespaceGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new NamespaceGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}