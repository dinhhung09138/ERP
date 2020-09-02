using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Security_Function")]
    public class Function
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Url { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Icon { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string ParentCode { get; set; }
        
        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        [Required]
        public string ModuleCode { get; set; }

    }
}
