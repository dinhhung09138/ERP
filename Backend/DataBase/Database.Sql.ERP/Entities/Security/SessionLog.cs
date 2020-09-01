using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    public class SessionLog
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        [MaxLength(500)]
        public string Token { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("Getdate()")]
        public DateTime LoginTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LogoutTime { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ExpirationTime { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(true)]
        public bool IsOnline { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string IPAddress { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Platform { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Browser { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string OSName { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Column(TypeName = "varchar(40)")]
        [Required]
        public string CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string UpdateBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [Column(TypeName = "varchar(40)")]
        public string DeleteBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DeleteDate { get; set; }
    }
}
