namespace FM.Common.Contracts
{
    public interface IServiceMapper
    {
        /// <summary>
        /// Maps the XLX to CSV.
        /// </summary>
        /// <param name="xlsFilePath">The XLS file path.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <returns>If the mapping was successful</returns>
        bool MapXlxToCsv(string xlsFilePath, string csvFilePath);
    }
}