using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class AppraiseQuestionModel : BaseModel
    {
        public int Id { get; set; }

        public int AppraiseSectionId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsInputAnswer { get; set; }
    }
}
