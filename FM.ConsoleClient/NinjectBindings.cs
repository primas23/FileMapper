using Ninject.Modules;

using FM.Common;
using FM.Common.Contracts;
using FM.Common.FileProviders;

namespace FM.ConsoleClient
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<FileLogger>();
            Bind<IFileManager>().To<FileManager>();

            Bind<IFileProvider>().To<CsvFileProvider>();
            Bind<IFileProvider>().To<XlsFileProvider>();
        }
    }
}
