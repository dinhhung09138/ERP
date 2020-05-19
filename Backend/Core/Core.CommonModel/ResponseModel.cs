using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    /// <summary>
    /// Model response object from the API.
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseModel"/> class.
        /// Constructor.
        /// </summary>
        public ResponseModel()
        {
            this.Errors = new List<string>();
            this.Extra = new List<object>();
        }

        /// <summary>
        /// Gets or sets response status code.
        /// </summary>
        public Enums.ResponseStatus ResponseStatus { get; set; } = Enums.ResponseStatus.Success;

        /// <summary>
        /// Gets or sets list of error or warning string.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets result object.
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Gets or sets extra data response.
        /// </summary>
        public List<object> Extra { get; set; }
    }
}
