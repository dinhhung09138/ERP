﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("EmployeeContractStatusHistory")]
    public class EmployeeContractStatusHistory
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ContractId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int StatusId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int SignId { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string Reason { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal GrossSalary { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal NetSalary { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

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
