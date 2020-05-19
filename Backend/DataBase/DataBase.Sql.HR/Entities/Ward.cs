using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.HR.Entities
{
    [Table("Ward")]
    public class Ward
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int DistrictId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ProvinceId { get; set; }
    }
}
