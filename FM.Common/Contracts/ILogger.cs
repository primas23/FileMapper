namespace FM.Common.Contracts
{
    public interface ILogger
    {
        /// <summary>
        /// Gets or sets the path where the text file should be created.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        string Path { get; set; }

        /// <summary>
        /// Writes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Write(string message);

        /// <summary>
        /// Writes the specified message on a new line.
        /// </summary>
        /// <param name="message">The message.</param>
        void WriteLine(string message);
    }
}
