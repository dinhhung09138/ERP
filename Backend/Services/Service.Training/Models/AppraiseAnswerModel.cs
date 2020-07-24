using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class AppraiseAnswerModel : BaseModel
    {
        public int Id { get; set; }

        public int AppraiseQuestionId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public int Point { get; set; }
    }
}
