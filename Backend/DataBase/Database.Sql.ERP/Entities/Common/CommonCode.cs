using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Common
{
    [Table("Common_Code")]
    public class CommonCode
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TypeId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime? ExpirationDate { get; set; }

    }
}
