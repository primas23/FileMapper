using System;

using FM.Common.Contracts;

namespace FM.Mapper
{
    public class ServiceMapper : IServiceMapper
    {
        private readonly IFileManager _fileManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Service that maps files from providers.
        /// </summary>
        /// <param name="fileManager">The file manager.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">
        /// fileManager is null
        /// or
        /// logger is null
        /// </exception>
        public ServiceMapper(IFileManager fileManager, ILogger logger)
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

        /// <summary>
        /// Maps the XLX to CSV.
        /// </summary>
        /// <param name="xlsFilePath">The XLS file path.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <returns>
        /// If the mapping was successful
        /// </returns>
        public bool MapXlxToCsv(string xlsFilePath, string csvFilePath)
        {
            // TODO: Guard clause

            var csv = _fileManager.GetFile("demo_utf8.csv");
            var xls = _fileManager.GetFile("orderslist_2017-03-13_125444.xls");

            return true;
        }
    }
}
