using System.IO;
using System.Xml.Serialization;

namespace ConfigComparer.Serializer
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>(string path)
        {
            T item;
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                item = (T)serializer.Deserialize(fs);
            }
            return item;
        }

        public void Serialize<T>(T item, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, item);
            }
        }
    }
}
