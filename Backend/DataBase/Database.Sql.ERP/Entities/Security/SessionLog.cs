﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Security_SessionLog")]
    public class SessionLog
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Token { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string RefreshToken { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime LoginTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? LogoutTime { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ExpirationTime { get; set; }

        [Column(TypeName = "bit")]
        [Required]
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
