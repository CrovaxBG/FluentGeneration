using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class SetBodyGeneratorTests
    {
        [Test]
        public void NonAutoBodyTest()
        {
            var generator = new SetBodyGenerator();
            var bodyData = new BodyData() { IsAuto = false, Body = "x = value;" };
            var result = generator.Generate(bodyData);

            Assert.AreEqual(@"set { x = value; }", result);
        }

        [Test]
        public void NonAutoNullBodyTest()
        {
            var generator = new SetBodyGenerator();
            var bodyData = new BodyData() { IsAuto = false, Body = "" };

            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(bodyData));
        }

        [Test]
        public void AutoBodyTest()
        {
            var generator = new SetBodyGenerator();
            var bodyData = new BodyData() { IsAuto = true, Body = "ShouldBeIgnored" };
            var result = generator.Generate(bodyData);

            Assert.AreEqual("set;", result);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new SetBodyGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new SetBodyGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}