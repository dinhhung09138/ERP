using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeEducationModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EducationTypeId { get; set; }

        public string EducationTypeName { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public string School { get; set; }

        [Required]
        public int MajorId { get; set; }

        public string MajorName { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int RankingId { get; set; }

        public string RankingName { get; set; }

        [Required]
        public int ModelOfStudyId { get; set; }

        public string ModelOfStudyName { get; set; }
    }
}
