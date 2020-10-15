using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeEducationModel : BaseModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public int SpecializedTrainingId { get; set; }

        public string SpecializedTrainingName { get; set; }

        public int Year { get; set; }

        public int TrainingTypeId { get; set; }

        public string TrainingTypeName { get; set; }

        public int RankingId { get; set; }

        public string RankingName { get; set; }

        public int ModelOfStudyId { get; set; }

        public string ModelOfStudyName { get; set; }
    }
}
