using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_Employee")]
    public class Employee
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int? AvatarFileId { get; set; }

        [Column(TypeName = "varchar(15)")]
        [MaxLength(15)]
        [Required]
        public string EmployeeCode { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ProbationDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? StartWorkingDate { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        public string BadgeCardNumber { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateApplyBadge { get; set; }

        [Column(TypeName = "varchar(10)")]
        [MaxLength(10)]
        public string FingerSignNumber { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateApplyFingerSign { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string WorkingEmail { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string WorkingPhone { get; set; }

        [Column(TypeName = "int")]
        public int EmployeeWorkingStatusId { get; set; }

        [Column(TypeName = "money")]
        public double BasicSalary { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool IsActive { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "int")]
        public int? UpdateBy { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Deleted { get; set; }

        [Column(TypeName = "timestamp")]
        public byte[] RowVersion { get; set; }
    }
}
