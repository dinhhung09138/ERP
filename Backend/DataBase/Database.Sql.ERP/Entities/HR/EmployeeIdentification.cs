using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("EmployeeIdentification")]
    public class EmployeeIdentification
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "varchar(15)")]
        [MaxLength(15)]
        [Required]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int PlaceId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TypeId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Notes { get; set; }

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

        [Column(TypeName = "timestamp")]
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
