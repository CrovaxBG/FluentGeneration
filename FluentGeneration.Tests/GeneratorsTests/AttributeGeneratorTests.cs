using System;
using System.ComponentModel.DataAnnotations;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class AttributeGeneratorTests
    {
        [Test]
        public void SingleAttributeTypeDataTest()
        {
            var generator = new AttributeGenerator();
            var attributes = new[] {typeof(System.ComponentModel.DataAnnotations.RequiredAttribute)}; 
            var result = generator.Generate(attributes);

            Assert.AreEqual("[System.ComponentModel.DataAnnotations.RequiredAttribute]", result);
        }

        [Test]
        public void MultipleAttributeTypeDataTest()
        {
            var generator = new AttributeGenerator();
            //literal + type
            var attributes = new[] {typeof(System.ComponentModel.DataAnnotations.RequiredAttribute), typeof(System.ComponentModel.DataAnnotations.RequiredAttribute) }; 
            var result = generator.Generate(attributes);

            Assert.AreEqual(@"[System.ComponentModel.DataAnnotations.RequiredAttribute]
[System.ComponentModel.DataAnnotations.RequiredAttribute]", result);
        }

        [TestCase("", ExpectedResult = "")]
        [TestCase("123", ExpectedResult = "123")]
        [TestCase(@"[System.Obsolete(""use something else"")]", ExpectedResult = @"[System.Obsolete(""use something else"")]")]
        public string LiteralDataTest(string data)
        {
            var generator = new AttributeGenerator();
            return generator.Generate(data);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new AttributeGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new AttributeGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}