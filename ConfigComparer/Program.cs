using System;
using System.Configuration;
using ConfigComparer.Comparer;
using ConfigComparer.Logger;
using ConfigComparer.Parser;
using ConfigComparer.Serializer;
using ConfigComparer.Unity;
using Unity;

namespace ConfigComparer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = Container.GetContainer;

            Console.WriteLine("Hello! This is a program for config files comparison. Please, read the 'README.txt' file before starting.");
            Console.WriteLine("Have you read it already? Press y/n");
            
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput == "n")
                {
                    Console.WriteLine("Please, read and come back! Press any key to close the program.");
                    Console.ReadKey();
                    return;
                }
                else if (userInput == "y")
                {
                    Console.WriteLine("Great, let's start.");
                    var cloudProjectName = ConfigurationManager.AppSettings["CloudProjectPath"];
                    var loyaltyProjectName = ConfigurationManager.AppSettings["LoyaltyProjectPath"];
                    var searchFile = ConfigurationManager.AppSettings["SearchFile"];
                    var loggerPath = ConfigurationManager.AppSettings["LoggerPath"];
                    var serializer = container.Resolve<ISerializer>(); 
                    var logger = container.Resolve<ILogger>();
                    var fileParser = new FileParser(serializer);
                    Console.WriteLine($"Are you sure you want to compare the config files in folders {cloudProjectName} and {loyaltyProjectName}? Press y/n");
                    while (true)
                    {
                        userInput = Console.ReadLine();
                        if (userInput == "n")
                        {
                            Console.WriteLine("Please, change folders paths in 'ConfigComparer.dll.config' and come back. Press any key to close the program.");
                            Console.ReadKey();
                            return;
                        }
                        else if (userInput == "y")
                        {
                            {
                                var comparer = new FilesComparer(logger, fileParser);
                                try
                                {
                                    comparer.GoCompare(cloudProjectName, loyaltyProjectName, searchFile, loggerPath);
                                }
                                catch (Exception ex)
                                {
                                    logger.LogException(ex);
                                }
                                Console.WriteLine($"Well done. You can find comparison result in {loggerPath} file. Press any key to close the program.");
                                Console.ReadKey();
                                return;
                            }
                        }
                        else Console.WriteLine("Wrong input! Press y/n");
                    }
                }
                else Console.WriteLine("Wrong input! Press y/n");
            }
        }
    }
}
