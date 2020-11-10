using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.System.Models
{
    public class UserModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        [MaxLength(40)]
        public string UserName { get; set; }

        public string RoleName { get; set; }

        [Required]
        public int RoleId { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        public List<UserRoleModel> Roles { get; set; }
    }
}
