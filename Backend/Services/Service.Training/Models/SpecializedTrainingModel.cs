using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class SpecializedTrainingModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }
    }
}
