using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class AppraiseModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
