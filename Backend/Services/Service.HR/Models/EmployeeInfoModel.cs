using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.HR.Models
{
    public class EmployeeInfoModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? ReligionId { get; set; }

        public int? EthnicityId { get; set; }

        public int? NationalityId { get; set; }

        public int? AcademicLevelId { get; set; }

        public int? ProfessionalQualificationId { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
