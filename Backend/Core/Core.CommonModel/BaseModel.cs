using Core.CommonModel.Enums;
using System;

namespace Core.CommonModel
{
    public class BaseModel
    {
        public FormActionStatus Action { get; set; } = FormActionStatus.Insert;
        public int Precedence { get; set; } = 1;
        public bool IsActive { get; set; } = true;

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Deleted { get; set; } = false;

        public byte[] RowVersion { get; set; }
    }
}
