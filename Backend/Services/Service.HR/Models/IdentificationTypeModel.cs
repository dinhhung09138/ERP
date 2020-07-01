﻿using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class IdentificationTypeModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
