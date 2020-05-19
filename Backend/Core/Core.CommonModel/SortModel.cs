using Core.CommonModel.Enums;
using Newtonsoft.Json;

namespace Core.CommonModel
{
    /// <summary>
    /// Sort model.
    /// </summary>
    public class SortModel
    {
        /// <summary>
        /// Gets or sets property name of column.
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// Gets or sets sort direction.
        /// </summary>
        public SortDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether allow order by multi column.
        /// </summary>
        public bool IsMultiOrder { get; set; } = false;

        /// <summary>
        /// Gets linq direction processing method.
        /// </summary>
        [JsonIgnore]
        public string LinqDirectionMethod
        {
            get
            {
                string method = null;
                if (this.Direction != SortDirection.None)
                {
                    switch (this.Direction)
                    {
                        case SortDirection.Ascending:
                            {
                                method = !this.IsMultiOrder ? "OrderBy" : "ThenBy";
                                break;
                            }

                        case SortDirection.Descending:
                            {
                                method = !this.IsMultiOrder ? "OrderByDescending" : "ThenByDescending";
                                break;
                            }
                    }
                }

                return method;
            }
        }
    }
}
