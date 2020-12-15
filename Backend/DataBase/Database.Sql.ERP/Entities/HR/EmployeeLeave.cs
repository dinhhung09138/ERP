using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_EmployeeLeave")]
    public class EmployeeLeave
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int LeaveTypeId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int LeaveStatusId { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime EndTime { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int LineManagerId { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string CCMember { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string Reason { get; set; }

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
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
