using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeEducationModel : BaseModel
    {
        public int Id { get; set; }

        public int EducationTypeId { get; set; }

        public string EducationTypeName { get; set; }

        public int EmployeeId { get; set; }

        public string School { get; set; }

        public int MajorId { get; set; }

        public string MajorName { get; set; }

        public int Year { get; set; }

        public int RankingId { get; set; }

        public string RankingName { get; set; }

        public int ModelOfStudyId { get; set; }

        public string ModelOfStudyName { get; set; }
    }
}
