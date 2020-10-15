using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Sql.ERP.Entities.HR
{
    [Table("HR_EmployeeContact")]
    public class EmployeeContact
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
        public string Phone { get; set; }

        [Column(TypeName = "varchar(15)")]
        [MaxLength(15)]
        public string Mobile { get; set; }

        [Column(TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        [MaxLength(50)]
        public string Skyper { get; set; }

        [Column(TypeName = "varchar(20)")]
        [MaxLength(20)]
        public string Zalo { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Facebook { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string LinkedIn { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Twitter { get; set; }

        [Column(TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Github { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string TemporaryAddress { get; set; }

        [Column(TypeName = "int")]
        public int? TemporaryWardId { get; set; }

        [Column(TypeName = "int")]  [Required]
        public int? TemporaryDistrictId { get; set; }

        [Column(TypeName = "int")]
        public int? TemporaryProvinceId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [MaxLength(250)]
        public string PermanentAddress { get; set; }

        [Column(TypeName = "int")]
        public int PermanentWardId { get; set; }

        [Column(TypeName = "int")]
        public int? PermanentDistrictId { get; set; }

        [Column(TypeName = "int")]
        public int? PermanentProvinceId { get; set; }

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
