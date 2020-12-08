using ConfigComparer.Comparer.Models;
using ConfigComparer.Parser.Models;

namespace ConfigComparer.Comparer
{
    public interface IFilesComparer
    { 
        FilesComparerResult GetDifferentValues(ParseResult result1, ParseResult result2);
        void GoCompare(string cloudProjectPath, string loyaltyProjectPath, string fileName, string loggerPath);
    }
}
