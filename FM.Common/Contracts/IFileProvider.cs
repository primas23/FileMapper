using FM.Models;

namespace FM.Common.Contracts
{
    public interface IFileProvider
    {
        /// <summary>
        /// Gets the file in rows format.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>A file with rows file format.</returns>
        RowsFile GetFile(string pathToFile);

        /// <summary>
        /// Determines whether this instance can handle the specified extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>
        ///   <c>true</c> if this instance can handle the specified extension; otherwise, <c>false</c>.
        /// </returns>
        bool CanHandle(string extension);
    }
}
