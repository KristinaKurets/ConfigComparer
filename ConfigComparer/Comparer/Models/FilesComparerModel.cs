using System.Collections.Generic;

namespace ConfigComparer.Comparer.Models
{
    public class FilesComparerModel
    {
        public string Key { get; set; }
        public Dictionary<string, string> ValuesPathsDictionary { get; set; }

    }
}
