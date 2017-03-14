using Ninject.Modules;

using FM.Common;
using FM.Common.Contracts;
using FM.Common.FileProviders;
using FM.Mapper;

namespace FM.ConsoleClient
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<FileLogger>();
            Bind<IFileManager>().To<FileManager>();
            Bind<IServiceMapper>().To<ServiceMapper>();

            Bind<IFileProvider>().To<CsvFileProvider>();
            Bind<IFileProvider>().To<XlsFileProvider>();
        }
    }
}
