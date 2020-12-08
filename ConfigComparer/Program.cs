using System;
using System.Configuration;
using ConfigComparer.Comparer;
using ConfigComparer.Parser;
using ConfigComparer.Serializer;

namespace ConfigComparer
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var cloudProjectName = ConfigurationManager.AppSettings["CloudProjectPath"];
            var loyaltyProjectName = ConfigurationManager.AppSettings["LoyaltyProjectPath"];
            var searchFile = ConfigurationManager.AppSettings["SearchFile"];
            var loggerPath = ConfigurationManager.AppSettings["LoggerPath"];
            var serializer = new Serializer.Serializer();
            var logger = new Logger.Logger(loggerPath);
            var fileParser = new FileParser(serializer);
            var comparer = new FilesComparer(logger, fileParser);

            try
            {
                comparer.GoCompare(cloudProjectName, loyaltyProjectName, searchFile, loggerPath);
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
            Console.WriteLine("Well done.");
            Console.ReadKey();
        }
    }
}
