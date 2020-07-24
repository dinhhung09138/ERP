using Core.CommonModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Training.Models
{
    public class TrainingCourseModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompleteDate { get; set; }

        public int LecturerId { get; set; }
    }
}
