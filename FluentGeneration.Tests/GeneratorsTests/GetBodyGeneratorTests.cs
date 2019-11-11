using System;
using FluentGeneration.Generators;
using FluentGeneration.Shared;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class GetBodyGeneratorTests
    {
        [Test]
        public void NonAutoBodyTest()
        {
            var generator = new GetBodyGenerator();
            var bodyData = new BodyData() {IsAuto = false, Body = "return 0;"};
            var result = generator.Generate(bodyData);

            Assert.AreEqual(@"get { return 0; }", result);
        }

        [Test]
        public void NonAutoNullBodyTest()
        {
            var generator = new GetBodyGenerator();
            var bodyData = new BodyData() {IsAuto = false, Body = ""};

            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(bodyData));
        }

        [Test]
        public void AutoBodyTest()
        {
            var generator = new GetBodyGenerator();
            var bodyData = new BodyData() {IsAuto = true, Body = "ShouldBeIgnored"};
            var result = generator.Generate(bodyData);

            Assert.AreEqual("get;", result);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new GetBodyGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new GetBodyGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }
    }
}