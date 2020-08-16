using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_ContractType")]
    public class ContractType
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool AllowInsurance { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool AllowLeaveDate { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }

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
