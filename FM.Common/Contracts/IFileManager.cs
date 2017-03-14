using FM.Models;

namespace FM.Common.Contracts
{
    public interface IFileManager
    {
        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The file in Rows format</returns>
        RowsFile GetFile(string path);
    }
}
