using System;
using System.IO;
using System.Collections.Generic;

using FM.Common.Contracts;
using FM.Models;

namespace FM.Common
{
    public class FileManager : IFileManager
    {
        private readonly IEnumerable<IFileProvider> _fileProviders;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManager"/> class with a Enumerable of file providers.
        /// </summary>
        /// <param name="fileProviders">The file providers.</param>
        /// <exception cref="ArgumentNullException">fileProviders is null</exception>
        public FileManager(IEnumerable<IFileProvider> fileProviders)
        {
            if (fileProviders == null)
            {
                throw new ArgumentNullException("fileProviders is null");
            }

            this._fileProviders = fileProviders;
        }

        /// <summary>
        /// Gets the file in rows format.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>The file in rows file format.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// pathToFile is null
        /// or
        /// file could not be found
        /// </exception>
        public RowsFile GetFile(string pathToFile)
        {
            if (string.IsNullOrWhiteSpace(pathToFile))
            {
                throw new ArgumentNullException("pathToFile is null");
            }

            if (File.Exists(pathToFile) == false)
            {
                throw new ArgumentNullException("file could not be found");
            }

            string extention = Path.GetExtension(pathToFile);

            foreach (IFileProvider fileProvider in this._fileProviders)
            {
                if (fileProvider.CanHandle(extention))
                {
                    return fileProvider.GetFile(pathToFile);
                }
            }

            return new RowsFile();
        }
    }
}
