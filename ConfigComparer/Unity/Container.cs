using System.Configuration;
using ConfigComparer.Comparer;
using ConfigComparer.Logger;
using ConfigComparer.Parser;
using ConfigComparer.Serializer;
using Unity;
using Unity.Injection;

namespace ConfigComparer.Unity
{
    public static class Container
    {
        private static IUnityContainer _container;
        public static IUnityContainer GetContainer
        {
            get
            {
                if (_container == null)
                    InitializeContainer();
                return _container;
            }
        }
        public static void InitializeContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<ISerializer, Serializer.Serializer>();
            _container.RegisterType<ILogger, Logger.Logger>(new InjectionConstructor(ConfigurationManager.AppSettings["LoggerPath"]));
            _container.RegisterType<IFileParser, FileParser>();
            _container.RegisterType<IFilesComparer, FilesComparer>();
        }
    }
}
