using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp9
{
    public class ModernArtifact : Artifact
    {
        public double TechLevel { get; set; }
        public string Manufacturer { get; set; }

        public override string ExportToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }

        public override string ExportToXml()
        {
            var serializer = new XmlSerializer(typeof(ModernArtifact));
            using (var writer = new System.IO.StringWriter())
            {
                serializer.Serialize(writer, this);
                return writer.ToString();
            }
        }
    }
}
