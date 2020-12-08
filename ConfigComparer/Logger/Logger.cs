using System;
using System.IO;

namespace ConfigComparer.Logger
{
    public class Logger : ILogger
    {
        private readonly string _path;

        public Logger(string path)
        {
            this._path = path;
        }
        public void LogError(string message)
        {
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine("ERROR!");
                sw.WriteLine(message);
            }
        }

        public void LogException(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(ex.Message);
            }
        }

        public void LogInfo(string message)
        {
            using (StreamWriter sw = new StreamWriter(_path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(message);
            }
        }
    }
}
