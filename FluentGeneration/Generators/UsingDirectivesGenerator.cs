using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using XmlReader = FluentGeneration.Shared.XmlReader;

namespace FluentGeneration.Generators
{
    public class UsingDirectivesGenerator : IGeneratableHandler
    {
        private const string UsingDirectivesFileName = @"UsingDirectives.xml";

        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is string[] directives)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (!directives.Any())
            {
                directives = GetDefaultDirectives().UsingDirectives;
            }

            return string.Join(Environment.NewLine, directives.Select(d => $"using {d};"));
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