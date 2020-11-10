using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeCertificateModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int CertificateId { get; set; }

        public string CertificateName { get; set; }

        [Required]
        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        [Required]
        public int year { get; set; }
    }
}
