﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.ERP.Entities.HR
{
    [Table("HR_ApproveStatus")]
    public class ApproveStatus
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        [MaxLength(10)]
        [Required]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Precedence { get; set; }

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
