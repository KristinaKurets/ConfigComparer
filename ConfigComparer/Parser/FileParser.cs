using ConfigComparer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConfigComparer.Parser.Models;
using ConfigComparer.Serializer;

namespace ConfigComparer.Parser
{
    public class FileParser : IFileParser
    {
        private readonly ISerializer _serializer;
        public FileParser(ISerializer serializer)
        {
            this._serializer = serializer;
        }

        private static Dictionary<string, string> FillDictionary(IEnumerable<AddModel> arrayFrom)
        {
            var dictionary = new Dictionary<string, string>();
            var addModels = arrayFrom.ToList();
            foreach (var model in addModels)
            {
                if (!dictionary.ContainsKey(model.Key))
                    dictionary.Add(model.Key, model.Value);
            }
            return dictionary;
        }
        
        public ParseResult Parse(string path, string fileName)
        {
            var result = new ParseResult();
            var resultList = new List<ParseModel>();
            foreach (var file in Directory.GetFiles(path, fileName, SearchOption.AllDirectories).Where(d=>!d.Contains("Debug")))
            {
                var configModel = _serializer.Deserialize<ConfigurationModel>(file);
                if (configModel.AppSettings != null)
                {
                    resultList.Add(new ParseModel()
                    {
                        Path = file,
                        UpDateTime = File.GetLastWriteTime(file),
                        AppSettings = FillDictionary(configModel.AppSettings.Add)
                    });
                }
                result.ParseModels = resultList;
            }
            return result;
        }
    }
}