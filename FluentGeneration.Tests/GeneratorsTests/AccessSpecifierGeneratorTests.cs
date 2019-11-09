using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class AccessSpecifierGeneratorTests
    {
        [TestCase(AccessSpecifier.None, ExpectedResult = "")]
        [TestCase(AccessSpecifier.Internal, ExpectedResult = "internal")]
        [TestCase(AccessSpecifier.Private, ExpectedResult = "private")]
        [TestCase(AccessSpecifier.Protected, ExpectedResult = "protected")]
        [TestCase(AccessSpecifier.ProtectedInternal, ExpectedResult = "protected internal")]
        [TestCase(AccessSpecifier.Public, ExpectedResult = "public")]
        public string AccessSpecifierConvertTest(AccessSpecifier accessSpecifier)
        {
            var generator = new AccessSpecifierGenerator();
            return generator.Generate(accessSpecifier);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new AccessSpecifierGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new AccessSpecifierGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate("Invalid"));
        }
    }
}