using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using FluentGeneration.Generators;
using NUnit.Framework;

namespace FluentGeneration.Tests.GeneratorsTests
{
    [TestFixture]
    public class UsingDirectivesGeneratorTests
    {
        [Test]
        public void MultipleDataTest()
        {
            var generator = new UsingDirectivesGenerator();

            var result = generator.Generate(new[]{"System.Collections", "System.Collections.Generic"});
            Assert.AreEqual(@"using System.Collections;
using System.Collections.Generic;", result);
        }

        [Test]
        public void SingleDataTest()
        {
            var generator = new UsingDirectivesGenerator();

            var result = generator.Generate(new[]{"System.Collections"});
            Assert.AreEqual("using System.Collections;", result);
        }

        [Test]
        public void EmptyDataTest()
        {
            var configs = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            if (!configs.Contains("UsingDirectives.xml"))
            {
                Assert.True(true);
                return;
            }

            var generator = new UsingDirectivesGenerator();

            var result = generator.Generate(new string[0]);

            var defaultUsingDirectives = GetDefaultDirectives().UsingDirectives;
            var expected = string.Join(Environment.NewLine, defaultUsingDirectives.Select(d => $"using {d};"));
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NullDataTest()
        {
            var generator = new UsingDirectivesGenerator();
            Assert.Throws(typeof(ArgumentNullException), () => generator.Generate(null));
        }

        [Test]
        public void InvalidDataTypeTest()
        {
            var generator = new UsingDirectivesGenerator();
            Assert.Throws(typeof(InvalidOperationException), () => generator.Generate(123));
        }

        private UsingDirectivesWrapper GetDefaultDirectives()
        {
            var xDoc = new XmlDocument();
            xDoc.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("FluentGeneration.UsingDirectives.xml"));

            using TextReader sr = new StringReader(xDoc.InnerXml);

            var serializer = new XmlSerializer(typeof(UsingDirectivesWrapper));
            return (UsingDirectivesWrapper)serializer.Deserialize(sr);
        }
    }
}