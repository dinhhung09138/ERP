using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    /// <summary>
    /// Filter model.
    /// </summary>
    public class FilterModel
    {
        /// <summary>
        /// Text search.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Pagination.
        /// </summary>
        public PagingModel Paging { get; set; } = new PagingModel();

        /// <summary>
        /// Sort model.
        /// </summary>
        public SortModel Sort { get; set; }
    }
}
