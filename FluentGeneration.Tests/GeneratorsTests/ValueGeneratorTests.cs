using System.Collections.Generic;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class ValueGeneratorTests
    {
        [Test]
        public void ListDataTest()
        {
            var generator = new ValueGenerator();

            var result = generator.Generate(new List<int> {1, 2, 3});
            Assert.AreEqual("System.Collections.Generic.List`1[System.Int32]", result);
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase(123, ExpectedResult = "123")]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(@"new List<int>{1, 2, 3}", ExpectedResult = @"new List<int>{1, 2, 3}")]
        public string LiteralDataTest(object data)
        {
            var generator = new ValueGenerator();
            return generator.Generate(data);
        }
        
        [Test]
        public void NullDataTest()
        {
            var generator = new ValueGenerator();

            var result = generator.Generate(null);
            Assert.AreEqual("null", result);
        }
    }
}