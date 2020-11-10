using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class DisciplineModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public decimal Money { get; set; }
    }
}
