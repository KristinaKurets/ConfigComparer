using System.Collections.Generic;
using System.Linq;
using ConfigComparer.Comparer.Models;
using ConfigComparer.Logger;
using ConfigComparer.Parser;
using ConfigComparer.Parser.Models;

namespace ConfigComparer.Comparer
{
    public class FilesComparer : IFilesComparer
    {
        private readonly ILogger _logger;
        private readonly IFileParser _fileParser;
        
        public FilesComparer(ILogger logger, IFileParser fileParser)
        {
            this._logger = logger;
            this._fileParser = fileParser;
        }

        public void GoCompare(string cloudProjectPath, string loyaltyProjectPath, string searchFile, string loggerPath)
        {
            var cloudParseResult = _fileParser.Parse(cloudProjectPath, searchFile);
            var loyaltyParseResult = _fileParser.Parse(loyaltyProjectPath, searchFile);
            var result = GetDifferentValues(cloudParseResult, loyaltyParseResult);
            if (result.FilesComparerModels.Count == 0 )
                _logger.LogInfo("There are no keys duplicates in these projects.");
            else
            {
                foreach (var item in result.FilesComparerModels)
                {
                    _logger.LogInfo($"\nThe key: '{item.Key}' \nValues:");
                    foreach (var (value, path) in item.ValuesPathsDictionary)
                    {
                        _logger.LogInfo($@"'{value}' in file {path}");
                    }
                }
            }
            _logger.LogInfo("\nNumber of encountered keys:\n");
            foreach (var (key, count) in result.KeysDuplicates.OrderByDescending(pair=>pair.Value))
            {
                _logger.LogInfo($"the key {key} encountered {count} times");
            }
        }
        public FilesComparerResult GetDifferentValues(ParseResult cloudResult, ParseResult loyaltyResult)
        {
            var filesComparerResult = new FilesComparerResult();
            var filesComparerModels = new List<FilesComparerModel>();
            var keysDuplicates = new Dictionary<string, int>();

            foreach (var cloudParseModel in cloudResult.ParseModels)
            {
                foreach (var cloudAppSetting in cloudParseModel.AppSettings)
                {
                    foreach (var loyaltyParseModel in loyaltyResult.ParseModels)
                    {
                        foreach (var loyaltyAppSetting in loyaltyParseModel.AppSettings)
                        {
                            if (cloudAppSetting.Key == loyaltyAppSetting.Key &&
                                cloudAppSetting.Value != loyaltyAppSetting.Value)
                            {
                                DuplicatesCounter(keysDuplicates, loyaltyAppSetting.Key);

                                filesComparerModels.Add(new FilesComparerModel()
                                {
                                    Key = cloudAppSetting.Key,
                                    ValuesPathsDictionary = FillValuesPathDictionary
                                    (
                                        cloudAppSetting.Value, cloudParseModel.Path,
                                        loyaltyAppSetting.Value, loyaltyParseModel.Path
                                    )
                                });
                            }
                        }
                    }
                }
            }

            filesComparerResult.FilesComparerModels = filesComparerModels;
            filesComparerResult.KeysDuplicates = keysDuplicates;

            return filesComparerResult;
        }
        private static void DuplicatesCounter(IDictionary<string, int> duplicateKeys, string key)
        {
            if (!duplicateKeys.ContainsKey(key))
                duplicateKeys.Add(key, 1);
            else
                duplicateKeys[key]++;
        }

        private static Dictionary<string, string> FillValuesPathDictionary(string cloudValue, string cloudPath, string loyaltyValue, string loyaltyPath)
        {
            var dictionary = new Dictionary<string, string>
            {
                { cloudValue, cloudPath },
                { loyaltyValue, loyaltyPath }
            };
            return dictionary;
        }
        
    }

}
