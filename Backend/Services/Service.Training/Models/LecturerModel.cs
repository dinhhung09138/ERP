using Core.CommonModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class LecturerModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(120)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Avatar { get; set; }

        public bool Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int? Rating { get; set; }

        public bool IsWorkInCenter { get; set; }

        public int? TrainingCenterId { get; set; }
    }
}
