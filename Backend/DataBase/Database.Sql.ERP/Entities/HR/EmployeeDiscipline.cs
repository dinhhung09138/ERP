using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("EmployeeDiscipline")]
    public class EmployeeDiscipline
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        [Required]
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

        [Column(TypeName = "varchar(250)")]
        [MaxLength(250)]
        public string Comment { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CommendationId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ProposerId { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ProposeDate { get; set; }

        [Column(TypeName = "int")]
        public int? ApprovedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ApprovedDate { get; set; }

        [Column(TypeName = "int")]
        public int? ApprovedStatusId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }

    }
}
