using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.System.Models
{
    public class FunctionCommandModel
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string FunctionCode { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string ModuleName { get; set; }

        [MaxLength(50)]
        public string ControllerName { get; set; }

        [MaxLength(50)]
        public string ActionName { get; set; }

        public int Precedence { get; set; }
    }
}
