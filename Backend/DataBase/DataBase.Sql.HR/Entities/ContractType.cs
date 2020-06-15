using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.HR.Entities
{
    [Table("ContractType")]
    public class ContractType
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool AllowInsurrance { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool AllowLeaveDate { get; set; }

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
