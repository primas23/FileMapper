using System.Collections.Generic;

namespace FM.Models
{
    /// <summary>
    /// File represented by rows
    /// </summary>
    public class RowsFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RowsFile"/> class.
        /// </summary>
        public RowsFile()
        {
            this.Headers = new Row();
            this.Rows = new List<Row>();
        }

        /// <summary>
        /// Gets or sets the headers of the file (the first row).
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public Row Headers { get; set; }

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public IList<Row> Rows { get; set; }
    }
}
