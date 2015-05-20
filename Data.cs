using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleScript
{
    /// <summary>
    /// The list of supported data types
    /// </summary>
    enum DataType
    {
        INT,
        STRING
    }

    // A piece of data
    class Data
    {
        /// <summary>
        /// The value of the data
        /// </summary>
        private Object value;

        /// <summary>
        /// The type of the data
        /// </summary>
        private DataType type;

        /// <summary>
        /// Initializes an instance of the Data class.
        /// </summary>
        /// <param name="type">The type of the data</param>
        /// <param name="value">The value of the data</param>
        public Data(DataType type, Object value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
