using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.System.Models
{
    public class FunctionCommandModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FunctionCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsView { get; set; }

        [MaxLength(50)]
        public string ModuleName { get; set; }

        [MaxLength(50)]
        public string ControllerName { get; set; }

        [MaxLength(50)]
        public string ActionName { get; set; }

        [Required]
        public int Precedence { get; set; }

        public bool Selected { get; set; } = false;
    }
}
