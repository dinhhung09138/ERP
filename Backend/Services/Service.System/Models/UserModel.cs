using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.System.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        [MaxLength(40)]
        public string UserName { get; set; }

        public string RoleName { get; set; }
        public int RoleId { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool IsActive { get; set; }

        public int CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }

        public bool Deleted { get; set; }

        public byte[] RowVersion { get; set; }

        public List<UserRoleModel> Roles { get; set; }
    }
}
