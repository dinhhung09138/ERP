using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.HR.Models
{
    public class AcademicLevelModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
