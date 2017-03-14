using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FM.Common;
using FM.Common.FileProviders;
using FM.Common.Contracts;
using FM.Mapper;

namespace FM.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var mapper = new FileMapper(new FileManager(new List<IFileProvider>() { new CsvFileProvider(), new XlsFileProvider() }), new FileLogger()).MapXlxToCsv("", "");
        }
    }
}
