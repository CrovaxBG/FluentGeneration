using System.IO;
using System.Xml.Serialization;

namespace FluentGeneration.Shared
{
    public static class XmlReader
    {
        public static UsingDirectivesWrapper Read(string fileName)
        {
            var xs = new XmlSerializer(typeof(UsingDirectivesWrapper));
            using var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var directives = (UsingDirectivesWrapper)xs.Deserialize(fs);
            return directives;
        }
    }
}