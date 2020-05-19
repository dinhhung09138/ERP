﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Gym.Models
{
    public class ExerciseResourceModel
    {
        public string Id { get; set; }

        [Required]
        public string ExerciseId { get; set; }

        public string Video { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public bool IsVideo { get; set; } = true;

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
