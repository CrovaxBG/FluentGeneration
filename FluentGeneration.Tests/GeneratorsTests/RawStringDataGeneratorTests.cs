using System;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class RawStringDataGeneratorTests
    {
        [TestCase("", ExpectedResult = "")]
        [TestCase("TestName", ExpectedResult = "TestName")]
        public string RawDataTest(string data)
        {
            var generator = new RawStringDataGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new RawStringDataGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new RawStringDataGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}