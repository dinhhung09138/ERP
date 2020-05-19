using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.Security.Entities
{
    public class User
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(40)")]
        [Required]
        [MaxLength(40)]
        public string UserName { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Password { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }

        [Column(TypeName = "varchar(40)")]
        [Required]
        public string CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string UpdatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string DeletedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeletedDate { get; set; }
    }
}
