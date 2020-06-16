using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class ContractTypeModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public bool AllowInsurance { get; set; }

        [Required]
        public bool AllowLeaveDate { get; set; }
    }
}
