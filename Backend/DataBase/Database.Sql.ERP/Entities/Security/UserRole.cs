using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Security_UserRole")]
    public class UserRole
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int UserId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int RoleId { get; set; }
    }
}
