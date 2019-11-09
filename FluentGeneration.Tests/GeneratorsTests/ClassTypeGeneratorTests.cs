using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class ClassTypeGeneratorTests
    {
        [TestCase(ClassType.Standard, ExpectedResult = "")]
        [TestCase(ClassType.Static, ExpectedResult = "static")]
        [TestCase(ClassType.Abstract, ExpectedResult = "abstract")]
        [TestCase(ClassType.Sealed, ExpectedResult = "sealed")]
        public string AccessSpecifierConvertTest(ClassType classType)
        {
            var generator = new ClassTypeGenerator();
            return generator.Generate(classType);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new ClassTypeGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new ClassTypeGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate("Invalid"));
        }
    }
}
