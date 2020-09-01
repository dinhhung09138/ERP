using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Security
{
    [Table("Secutiry_SystemLog")]
    public class SystemLog
    {
        [Key]
        [Column(TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string MessageTemplate { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Level { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? TimeStamp { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Exception { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Properties { get; set; }
    }
}
