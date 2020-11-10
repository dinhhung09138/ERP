using Core.CommonModel.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.CommonModel
{
    public class BaseModel
    {
        public FormActionStatus Action { get; set; } = FormActionStatus.Insert;

        [Required]
        public int Precedence { get; set; } = 1;

        [Required]
        public bool IsActive { get; set; } = true;

        public int CreateBy { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Deleted { get; set; } = false;

        public byte[] RowVersion { get; set; }
    }
}
