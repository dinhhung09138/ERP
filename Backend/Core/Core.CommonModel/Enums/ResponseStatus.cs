using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel.Enums
{
    /// <summary>
    /// Response status code enum.
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// Response successful.
        /// </summary>
        Success = 1,

        /// <summary>
        /// Warning response.
        /// </summary>
        Warning = 0,

        /// <summary>
        /// Error response.
        /// </summary>
        Error = -1,

        /// <summary>
        /// Show when code is exists
        /// </summary>
        CodeExists = -2,

        /// <summary>
        /// Show when user name is exists
        /// </summary>
        UserNameExists = -3,

        /// <summary>
        /// Current password not match
        /// </summary>
        CurrentPasswordNotMatch = -4,

        /// <summary>
        /// Error when get dropdown data
        /// </summary>
        GetDropDownError = -3,

        /// <summary>
        /// Version is not map. Data was changed before
        /// </summary>
        OutOfDateData = -4,

    }
}
