using ConfigComparer.Parser.Models;

namespace ConfigComparer.Parser
{
    public interface IFileParser
    {
        ParseResult Parse(string path, string fileName);
    };
}
