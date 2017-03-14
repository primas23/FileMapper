using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

using FM.Common.Contracts;
using FM.Models;

namespace FM.Common.FileProviders
{
    public class XlsFileProvider : IFileProvider
    {
        /// <summary>
        /// Gets the file xls.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>The xls file in rows file format</returns>
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
            
            int rowIndex;
            int columnIndex;
            int rowsCount = 0;
            int columnsCount = 0;

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(Path.Combine(Environment.CurrentDirectory, pathToFile),
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                "\t",
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing,
                                                                Type.Missing);

            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];

            Excel.Range range = xlWorkSheet.UsedRange;
            rowsCount = range.Rows.Count;
            columnsCount = range.Columns.Count;


            for (rowIndex = 1; rowIndex <= rowsCount; rowIndex++)
            {
                List<string> list = new List<string>();

                for (columnIndex = 1; columnIndex <= columnsCount; columnIndex++)
                {
                    list.Add(range.Cells[rowIndex, columnIndex].Value2.ToString());
                }

                if (rowsFile.Headers.ColumnList.Any() == false)
                {
                    rowsFile.Headers.ColumnList = list;
                }
                else
                {
                    rowsFile.Rows.Add(new Row() { ColumnList = list });
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

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
            return string.Equals(".xls", extension);
        }
    }
}
