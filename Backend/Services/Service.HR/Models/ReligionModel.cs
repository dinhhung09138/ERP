﻿using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class ReligionModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
