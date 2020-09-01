using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Security_Module")]
    public class Module
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Url { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Icon { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ParentCode { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }
    }
}
