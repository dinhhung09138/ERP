using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class TrainingCenterModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        public string Avatar { get; set; }

        [MaxLength(20)]
        public string TaxCode { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }
}
