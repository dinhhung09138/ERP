using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.HR.Models
{
    public class ApproveStatusModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
