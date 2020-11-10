﻿using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Common.Models
{
    public class ProfessionalQualificationModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
