﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.Gym.Enitties
{
    [Table("GymExerciseResource")]
    public class ExerciseResource
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid ExerciseId { get; set; }

        [Column(TypeName = "varchar(350)")]
        [MaxLength(350)]
        public string Video { get; set; }

        [Column(TypeName = "varchar(1000)")]
        [MaxLength(1000)]
        public string Image { get; set; }

        [Column(TypeName = "varchar(1000)")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Column(TypeName = "varchar(1000)")]
        [MaxLength(1000)]
        public string Notes { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(true)]
        public bool IsVideo { get; set; }

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