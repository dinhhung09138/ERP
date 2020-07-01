using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class ContractTypeModel : BaseModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public bool AllowInsurance { get; set; }

        public bool AllowLeaveDate { get; set; }
    }
}
