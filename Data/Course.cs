namespace GolfClashHelper
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class Course
    {
        public string Name { get; set; }
        
        [XmlIgnore]
        public string Folder { get; set; }
        public Hole[] Holes { get; set; }

        public void SaveXML(string xmlFilePath)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                var serializer = new XmlSerializer(typeof(Course));

                serializer.Serialize(writer, this);
            }

            doc.Save(xmlFilePath);
        }

        public static Course LoadXML(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(Course));
            using var fs = new FileStream(xmlFilePath, FileMode.Open);
            Course course = (Course)serializer.Deserialize(fs);
            return course;
        }
    }

    public class Hole
    {
        public int ID { get; set; }
        
        public int Par { get; set; }
        
        public int Shot1 { get; set; }
        
        public int Shot2 { get; set; }
        
        public int Shot3 { get; set; }

        public CData Comment { get; set; }

        [XmlIgnore]
        public string HoleImage { get; set; }
        [XmlIgnore]
        public Image HoleImageBitmap { get; set; }
        [XmlIgnore]
        public string GuideImage { get; set; }
        [XmlIgnore]
        public Image GuideImageBitmap { get; set; }
        [XmlIgnore]
        public string CourseName { get; set; }
    }
}