using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Common
{
    [Table("Common_File")]
    public class File
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        [Column(TypeName = "decimal(12, 0)")]
        [Required]
        public decimal Size { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50)]
        public string MineType { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        [MaxLength(10)]
        public string Extension { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        [MaxLength(100)]
        public string SystemFileName { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath32 { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath64 { get; set; }

        [Column(TypeName = "varchar(300)")]
        [MaxLength(300)]
        public string FilePath128 { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDate { get; set; }
    }
}
