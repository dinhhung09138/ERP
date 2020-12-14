using Core.CommonModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeDependencyModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public int RelationshipTypeId { get; set; }
        public string RelationshipTypeName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }

        }
    }
}
