using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Security_FunctionCommand")]
    public class FunctionCommand
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string FunctionCode { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ModuleName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string ControllerName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string ActionName { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }

    }
}
