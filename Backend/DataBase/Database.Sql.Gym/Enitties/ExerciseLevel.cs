using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.Gym.Enitties
{
    [Table("GymExcerciseLevel")]
    public class ExerciseLevel
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Range(1, 1000)]
        [DefaultValue(1)]
        public int Precedence { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

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
