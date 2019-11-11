using System;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class NameGeneratorTests
    {
        [TestCase("", ExpectedResult = "")]
        [TestCase("TestName", ExpectedResult = "TestName")]
        public string NameTest(string data)
        {
            var generator = new NameGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new NameGenerator();
            var result = generator.Generate(null);
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new NameGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}