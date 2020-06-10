﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Gym.Models
{
    public class ExerciseLevelModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}