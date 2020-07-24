using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class TrainingCourseDocumentModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public int FileId { get; set; }

        public int TrainingCourseId { get; set; }
    }
}
