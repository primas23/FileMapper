using System;

using FM.Common.Contracts;

namespace FM.Mapper
{
    public class FileMapper
    {
        private readonly IFileManager _fileManager;
        private readonly ILogger _logger;

        public FileMapper(IFileManager fileManager, ILogger logger)
        {
            if (fileManager == null)
            {
                throw new ArgumentNullException("fileManager is null");
            }

            if (logger == null)
            {
                throw new ArgumentNullException("logger is null");
            }

            this._fileManager = fileManager;
            this._logger = logger;
        }

        public bool MapXlxToCsv(string xlsFilePath, string csvFilePath)
        {
            // TODO: Guard clause

            //_fileProvider.GetFile("demo_utf8.csv");
            _fileManager.GetFile("orderslist_2017-03-13_125444.xls");

            return true;
        }
    }
}
