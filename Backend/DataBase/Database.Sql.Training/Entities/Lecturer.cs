using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.Training.Entities
{
    [Table("Training_Lecturer")]
    public class Lecturer
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(120)")]
        [MaxLength(120)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string Avatar { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Gender { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string Fax { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "int")]
        public float? Rating { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool IsWorkInCenter { get; set; }

        [Column(TypeName = "int")]
        public int? TrainingCenterId { get; set; }

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
