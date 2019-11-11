using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class MethodBodyGeneratorTests
    {
        [Test]
        public void NonAutoBodyTest()
        {
            var generator = new MethodBodyGenerator();
            var bodyData = new BodyData() { IsAuto = false, Body = "x = value;" };
            var result = generator.Generate(bodyData);

            Assert.AreEqual(@"{ x = value; }", result);
        }

        [Test]
        public void NonAutoNullBodyTest()
        {
            var generator = new MethodBodyGenerator();
            var bodyData = new BodyData() { IsAuto = false, Body = "" };
            var result = generator.Generate(bodyData);
            Assert.AreEqual("{  }", result);
        }

        [Test]
        public void AutoBodyTest()
        {
            var generator = new MethodBodyGenerator();
            var bodyData = new BodyData() { IsAuto = true, Body = "ShouldBeIgnored" };
            var result = generator.Generate(bodyData);

            Assert.AreEqual(";", result);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new MethodBodyGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new MethodBodyGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}