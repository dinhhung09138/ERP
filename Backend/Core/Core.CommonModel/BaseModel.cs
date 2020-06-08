using Core.CommonModel.Enums;
using System;

namespace Core.CommonModel
{
    public class BaseModel
    {
        public FormActionStatus Action { get; set; } = FormActionStatus.Insert;
        public int Precedence { get; set; } = 1;
        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Deleted { get; set; } = false;

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
