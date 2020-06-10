using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.HR.Entities
{
    [Table("EmployeeContact")]
    public class EmployeeContact
    {
        [Key]
        [Column(TypeName = "int")]
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

        [Column(TypeName = "varchar(250)")]
        [MaxLength(250)]
        public string TemporaryAddress { get; set; }

        [Column(TypeName = "int")]
        public int? TemporaryWardId { get; set; }

        [Column(TypeName = "int")]  [Required]
        public int? TemporaryDistrictId { get; set; }

        [Column(TypeName = "int")]
        public int? TemporaryCityId { get; set; }

        [Column(TypeName = "varchar(250")]
        [MaxLength(250)]
        public string PermanentAddress { get; set; }

        [Column(TypeName = "int")]
        public int PermanentWardId { get; set; }

        [Column(TypeName = "int")]
        public int? PermanentDistrictId { get; set; }

        [Column(TypeName = "int")]
        public int? PermanentCityId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ExpirationDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CreateBy { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("getdate()")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "int")]
        public int? UpdateBy { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [Column(TypeName = "int")]
        public int? DeletedBy { get; set; }
    }
}
