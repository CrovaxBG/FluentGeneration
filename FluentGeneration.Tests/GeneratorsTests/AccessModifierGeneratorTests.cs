using System;
using System.Collections.Generic;
using System.Text;
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
            return generator.Generate(new GenerationData(null, accessModifiers));
        }
    }
}
