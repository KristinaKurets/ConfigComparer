using System.Xml.Serialization;

namespace ConfigComparer.Models
{
    [XmlRoot(ElementName = "configuration")]
    public class ConfigurationModel
    {
        [XmlElement(ElementName = "appSettings")]
        public AppSettingsModel AppSettings { get; set; }
    }
}
