using System;
using System.IO;
using System.Linq;

using FM.Common.Contracts;
using FM.Models;

namespace FM.Common
{
    public class CsvFileProvider : IFileProvider
    {
        /// <summary>
        /// Gets the file csv.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>The csv file in rows file format</returns>
        public RowsFile GetFile(string pathToFile)
        {
            if (string.IsNullOrWhiteSpace(pathToFile))
            {
                throw new ArgumentNullException("pathToFile is null");
            }

            if (File.Exists(pathToFile) == false)
            {
                return new RowsFile();
            }

            RowsFile rowsFile = new RowsFile();

            using (var reader = new StreamReader(File.OpenRead(pathToFile)))
            {
                bool isHeader = true;

                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(';');

                    if (isHeader)
                    {
                        rowsFile.Headers.ColumnList = values.ToList();
                    }
                    else
                    {
                        rowsFile.Rows.Add(new Row()
                        {
                            ColumnList = values.ToList()
                        });
                    }

                    isHeader = false;
                }
            }

            return rowsFile;
        }

        /// <summary>
        /// Determines whether this instance can handle the specified extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>
        ///   <c>true</c> if this instance can handle the specified extension; otherwise, <c>false</c>.
        /// </returns>
        public bool CanHandle(string extension)
        {
            return string.Equals(".csv", extension);
        }
    }
}
