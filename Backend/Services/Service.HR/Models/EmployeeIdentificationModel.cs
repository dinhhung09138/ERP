using Core.CommonModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeIdentificationModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Code { get; set; }

        public DateTime? ApplyDate { get; set; }

        [Required]
        public int PlaceId { get; set; }

        public string PlaceName { get; set; }

        [Required]
        public int IdentificationTypeId { get; set; }

        public string IdentificationTypeName { get; set; }

        [MaxLength(100)]
        public string Notes { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
