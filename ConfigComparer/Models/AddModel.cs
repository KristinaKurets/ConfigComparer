using System.Xml.Serialization;

namespace ConfigComparer.Models
{
    public class AddModel
    {
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
