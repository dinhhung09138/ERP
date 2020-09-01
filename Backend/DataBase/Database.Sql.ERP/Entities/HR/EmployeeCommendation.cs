using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("EmployeeCommendation")]
    public class EmployeeCommendation
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Money { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [MaxLength(250)]
        public string Comment { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CommendationId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ProposerId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ProposeDate { get; set; }

        [Column(TypeName = "int")]
        public int? ApprovedStatus { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ApprovedDate { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ApprovedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ExpirationDate { get; set; }

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
