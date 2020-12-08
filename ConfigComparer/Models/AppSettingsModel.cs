using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConfigComparer.Models
{
    public class AppSettingsModel
    {
        [XmlElement(ElementName = "add")]
        public List<AddModel> Add { get; set; }
    }
}
