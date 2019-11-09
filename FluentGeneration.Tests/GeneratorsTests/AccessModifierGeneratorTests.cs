using System;
using FluentGeneration.Generators;
using NUnit.Framework;
using FluentGeneration.Shared;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class AccessModifierGeneratorTests
    {
        [TestCase(AccessModifiers.None, ExpectedResult = "")]
        [TestCase(AccessModifiers.Const, ExpectedResult = "const")]
        [TestCase(AccessModifiers.Readonly, ExpectedResult = "readonly")]
        [TestCase(AccessModifiers.Static, ExpectedResult = "static")]
        [TestCase(AccessModifiers.Volatile, ExpectedResult = "volatile")]
        public string SingleAccessModifierConvertTest(AccessModifiers accessModifiers)
        {
            var generator = new AccessModifierGenerator();
            return generator.Generate(accessModifiers);
        }

        [TestCase(AccessModifiers.None | AccessModifiers.Const, ExpectedResult = "const")]
        [TestCase(AccessModifiers.Const | AccessModifiers.Static, ExpectedResult = "const static")]
        [TestCase(AccessModifiers.Static | AccessModifiers.Readonly, ExpectedResult = "static readonly")]
        [TestCase(AccessModifiers.Readonly | AccessModifiers.Volatile, ExpectedResult = "readonly volatile")]
        [TestCase(AccessModifiers.Volatile | AccessModifiers.None, ExpectedResult = "volatile")]
        public string MultipleAccessModifierConvertTest(AccessModifiers accessModifiers)
        {
            var generator = new AccessModifierGenerator();
            return generator.Generate(accessModifiers);
        }

        [TestCase(AccessModifiers.None | AccessModifiers.Const | AccessModifiers.Static | AccessModifiers.Readonly | AccessModifiers.Volatile, ExpectedResult = "const static readonly volatile")]
        public string AllModifiersConvertTest(AccessModifiers accessModifiers)
        {
            var generator = new AccessModifierGenerator();
            return generator.Generate(accessModifiers);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new AccessModifierGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new AccessModifierGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate("Invalid"));
        }
    }
}
