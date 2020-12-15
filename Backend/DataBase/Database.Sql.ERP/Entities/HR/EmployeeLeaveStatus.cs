using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_EmployeeLeaveStatus")]
    public class EmployeeLeaveStatus
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int ApproveBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ApproveDate { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string ApproveComment { get; set; }

    }
}
