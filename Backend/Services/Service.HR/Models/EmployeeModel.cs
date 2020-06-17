using Core.CommonModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string EmployeeCode { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName ?? ""} {LastName ?? "" }";
            }
        }

        public DateTime? ProbationDate { get; set; }

        public DateTime? StartWorkingDate { get; set; }

        [MaxLength(10)]
        public string BadgeCardNumber { get; set; }

        public DateTime? DateApplyBadge { get; set; }

        [MaxLength(10)]
        public string FingerSignNumber { get; set; }

        public DateTime? DateApplyFingerSign { get; set; }

        [MaxLength(50)]
        public string WorkingEmail { get; set; }

        [MaxLength(25)]
        public string WorkingPhone { get; set; }

        public int EmployeeWorkingStatusId { get; set; }

        public double BasicSalary { get; set; }
    }
}
