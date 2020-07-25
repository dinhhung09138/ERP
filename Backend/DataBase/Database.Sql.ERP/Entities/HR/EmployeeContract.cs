using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.ERP.Entities.HR
{
    [Table("EmployeeContract")]
    public class EmployeeContract
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        [Required]
        public string ContractNumber { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeProcessId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ContractTypeId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FromDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ToDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SignOn { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Comment { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal GrossSalary { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal NetSalary { get; set; }

        [Column(TypeName = "int")]
        public int? ContractStatusId { get; set; }

        [Column(TypeName = "int")]
        public int? ContractStatusSignId { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string ContractStatusReason { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ContractStatusDate { get; set; }

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
    }
}
