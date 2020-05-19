using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.Gym.Models
{
    public class MuscleModel
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        public int Precedence { get; set; } = 1;

        public bool IsActive { get; set; } = true;

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = new DateTime();

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool Deleted { get; set; } = false;

        public string DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
