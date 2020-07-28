﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.ERP.Entities.HR
{
    [Table("EmployeeInfo")]
    public class EmployeeInfo
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Gender { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "int")]
        public int? MaterialStatusId { get; set; }

        [Column(TypeName = "int")]
        public int? ReligionId { get; set; }

        [Column(TypeName = "int")]
        public int? NationId { get; set; }

        [Column(TypeName = "int")]
        public int? NationalityId { get; set; }

        [Column(TypeName = "int")]
        public int? AcademicLevelId { get; set; }

        [Column(TypeName = "int")]
        public int? ProfessionalQualificationId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

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