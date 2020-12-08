using System.Collections.Generic;

namespace ConfigComparer.Comparer.Models
{
    public class FilesComparerResult
    {
        public List<FilesComparerModel> FilesComparerModels { get; set; }
        public Dictionary<string, int> KeysDuplicates { get; set; }
    }
}
