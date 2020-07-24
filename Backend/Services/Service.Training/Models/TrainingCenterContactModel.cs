using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class TrainingCenterContactModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Position { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Fax { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public int TrainingCenterId { get; set; }
    }
}
