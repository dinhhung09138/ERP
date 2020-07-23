using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.Training.Entities
{
    [Table("Training_AppraiseSection")]
    public class AppraiseSection
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int AppraiseId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool IsActive { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "int")]
        public int? UpdateBy { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Deleted { get; set; }
    }
}
