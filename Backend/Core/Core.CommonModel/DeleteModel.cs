using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.CommonModel
{
    /// <summary>
    /// Use this class for Delete action
    /// </summary>
    public class DeleteModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public byte[] RowVersion { get; set; }
    }
}
