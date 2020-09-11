using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Security_UserModule")]
    public class UserModule
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]

        public User User { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string ModuleCode { get; set; }

        [ForeignKey("ModuleCode")]
        public Module Module { get; set; }
    }
}
