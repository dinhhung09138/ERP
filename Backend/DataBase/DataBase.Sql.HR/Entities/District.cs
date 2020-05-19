using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Sql.HR.Entities
{
    [Table("District")]
    public class District
    {
        [Key]
        [Column(TypeName = "int")]
        public int I { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ProvinceId { get; set; }       
    }
}
