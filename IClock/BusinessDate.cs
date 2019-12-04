using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace IClock
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {
        public BusinessDate(DateTime time)
        {
            this.BusinessDateTime = time;
            this.Type = time.GetType().Name;
            this.Format = "LongDate";
        }

        public string Type
        {
            get;

            set;
        }

        public string Format
        {
            get;

            set;
        }

        public DateTime BusinessDateTime
        {
            get;

            set;
        }

        public int CompareTo(BusinessDate other)
        {
            return this.BusinessDateTime.CompareTo(other.BusinessDateTime);
        }

        public bool Equals(BusinessDate other)
        {
            return this.BusinessDateTime.CompareTo(other.BusinessDateTime) == 0;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            this.Type = reader.GetAttribute("Type");
            this.Format = reader.GetAttribute("Format");
            Boolean isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();

            if (!isEmptyElement)
            {
                this.BusinessDateTime = DateTime.Parse(reader.ReadElementString("BusinessDateTime"));
                reader.ReadEndElement();
            }
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return DateTime.Parse(this.BusinessDateTime.ToLongDateString()).ToString(format, formatProvider);
        }

        public override string ToString()
        {
            return this.ToString("dd/MM/yy HH:mm:ss.fff", CultureInfo.InvariantCulture);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Type", this.Type);
            writer.WriteAttributeString("Format", this.Format);
            writer.WriteElementString("BusinessDateTime", this.BusinessDateTime.ToLongDateString());
        }
    }
}
