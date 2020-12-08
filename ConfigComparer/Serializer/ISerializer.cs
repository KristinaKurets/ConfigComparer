
namespace ConfigComparer.Serializer
{
    public interface ISerializer
    {
        void Serialize<T>(T item, string path);
        T Deserialize<T>(string path);
    }
}
