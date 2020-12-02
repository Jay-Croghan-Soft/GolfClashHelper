using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GolfClashHelper
{

    public class Contents
    {
        public int Version { get; set; }
        public Tour[] Tours { get; set; }

        public void SaveXML(string xmlFilePath)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                var serializer = new XmlSerializer(typeof(Contents));

                serializer.Serialize(writer, this);
            }

            doc.Save(xmlFilePath);
        }

        public static Contents LoadXML(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(Contents));
            using var fs = new FileStream(xmlFilePath, FileMode.Open);
            Contents contents = (Contents)serializer.Deserialize(fs);
            return contents;
        }
    }

    public class Tour
    {
        public string Name { get; set; }
        public Courselink[] CourseLinks { get; set; }
    }

    public class Courselink
    {
        public string Name { get; set; }
    }

}
