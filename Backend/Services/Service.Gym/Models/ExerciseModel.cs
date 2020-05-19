using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Gym.Models
{
    public class ExerciseModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string MainMuscleId { get; set; }

        public string SecondaryMuscleIds { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public int HardLevel { get; set; } = 1;

        [Range(1, 1000)]
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
