﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_EmployeeEducation")]
    public class EmployeeEducation
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EducationTypeId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int SchoolId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int MajorId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Year { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int RankingId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ModelOfStudyId { get; set; }

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
