using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Training
{
    [Table("Training_TrainingCourse")]
    public class TrainingCourse
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CompleteDate { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int LecturerId { get; set; }

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

        [Column(TypeName = "timestamp")]
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
