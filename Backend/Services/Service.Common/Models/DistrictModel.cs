using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Common.Models
{
    public class DistrictModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }
    }
}
