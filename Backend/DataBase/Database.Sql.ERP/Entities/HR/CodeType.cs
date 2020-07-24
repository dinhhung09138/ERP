using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.ERP.Entities.HR
{
    [Table("CodeType")]
    public class CodeType
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public int TypeCode { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string ModuleCode { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string ModuleName { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }
    }
}
