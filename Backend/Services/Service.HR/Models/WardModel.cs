using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class WardModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int DistrictId { get; set; }

        public string DistrictName { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; }
    }
}
