using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class DistrictModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }

    }
}
