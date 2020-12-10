using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeBankModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int BankId { get; set; }

        public string BankName { get; set; }

        [MaxLength(100)]
        [Required]
        public string BankAddress { get; set; }

        [MaxLength(100)]
        [Required]
        public string AccountNumber { get; set; }

        [MaxLength(100)]
        [Required]
        public string AccountOwner { get; set; }
    }
}
