using System;
using System.Collections.Generic;

namespace ConfigComparer.Parser.Models
{
    public class ParseModel
    {
        public string Path { get; set; }
        public Dictionary<string, string> AppSettings { get; set; }
        public DateTime UpDateTime { get; set; }
    }
}
