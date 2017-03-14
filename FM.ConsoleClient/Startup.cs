using Ninject;

using FM.Common.Contracts;

namespace FM.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjectBindings());

            IServiceMapper mapper = kernel.Get<IServiceMapper>();
            mapper.MapXlxToCsv("asdasd", "asdasd");
        }
    }
}
