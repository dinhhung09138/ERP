using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.System.Models
{
    public class FunctionModel
    {
        [MaxLength(20)]
        public string Code { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Url { get; set; }

        [MaxLength(255)]
        public string Icon { get; set; }

        [MaxLength(20)]
        public string ParentCode { get; set; }

        [Required]
        public int Precedence { get; set; }

        [MaxLength(20)]
        public string ModuleCode { get; set; }

        public List<FunctionCommandModel> Commands { get; set; } = new List<FunctionCommandModel>();
    }
}
