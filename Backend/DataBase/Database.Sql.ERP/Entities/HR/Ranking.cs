﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_Ranking")]
    public class Ranking
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

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
