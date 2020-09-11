
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Service.System.Models
{
    public class ModuleModel
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

        public int Precedence { get; set; }

        public List<FunctionModel> Functions { get; set; } = new List<FunctionModel>();
    }
}
