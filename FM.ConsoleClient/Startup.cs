using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ninject;

using FM.Common.Contracts;
using FM.Mapper;

namespace FM.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjectBindings());

            var mapper = new ServiceMapper(kernel.Get<IFileManager>(), kernel.Get<ILogger>());
            mapper.MapXlxToCsv("", "");
        }
    }
}
