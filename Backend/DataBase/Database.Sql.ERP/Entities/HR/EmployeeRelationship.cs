using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.ERP.Entities.HR
{
    [Table("EmployeeRelationship")]
    public class EmployeeRelationship
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int RelationshipTypeId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "varchar(15)")]
        [MaxLength(15)]
        public string Mobile { get; set; }

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
