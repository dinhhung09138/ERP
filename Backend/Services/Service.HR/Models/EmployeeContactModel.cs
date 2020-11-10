using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class EmployeeContactModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }

        [MaxLength(15)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Skyper { get; set; }

        [MaxLength(20)]
        public string Zalo { get; set; }

        [MaxLength(200)]
        public string Facebook { get; set; }

        [MaxLength(200)]
        public string LinkedIn { get; set; }

        [MaxLength(200)]
        public string Twitter { get; set; }

        [MaxLength(200)]
        public string Github { get; set; }

        [MaxLength(250)]
        public string TemporaryAddress { get; set; }

        public int? TemporaryWardId { get; set; }

        public string TemporaryWardName { get; set; }

        public int? TemporaryDistrictId { get; set; }

        public string TemporaryDistrictName { get; set; }

        public int? TemporaryProvinceId { get; set; }

        public string TemporaryProvinceName { get; set; }

        [MaxLength(250)]
        public string PermanentAddress { get; set; }

        public int PermanentWardId { get; set; }

        public string PermanentWardName { get; set; }

        public int? PermanentDistrictId { get; set; }

        public string PermanentDistrictName { get; set; }

        public int? PermanentProvinceId { get; set; }

        public string PermanentProvinceName { get; set; }

    }
}
