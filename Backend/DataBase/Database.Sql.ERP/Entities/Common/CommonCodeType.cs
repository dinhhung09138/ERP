using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Common
{
    [Table("Common_CodeType")]
    public class CommonCodeType
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        [MaxLength(30)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string ModuleName { get; set; }
    }
}
