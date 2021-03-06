﻿namespace GolfClashHelper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class CData : IXmlSerializable
    {
        private string _value;

        /// <summary>
        /// Allow direct assignment from string:
        /// CData cdata = "abc";
        /// </summary>
        /// <param name="value">The string being cast to CData.</param>
        /// <returns>A CData object</returns>
        public static implicit operator CData(string value)
        {
            return new CData(value);
        }

        /// <summary>
        /// Allow direct assignment to string:
        /// string str = cdata;
        /// </summary>
        /// <param name="cdata">The CData being cast to a string</param>
        /// <returns>A string representation of the CData object</returns>
        public static implicit operator string(CData cdata)
        {
            return cdata == null ? string.Empty : cdata._value;
        }

        public CData() : this(string.Empty)
        {
        }

        public CData(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            _value = reader.ReadElementContentAsString().Replace("\n","\r\n");
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteCData(_value);
        }
    }
}
