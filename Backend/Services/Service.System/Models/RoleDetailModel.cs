
using System.ComponentModel.DataAnnotations;

namespace Service.System.Models
{
    public class RoleDetailModel
    {
        public int Id { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int CommandId { get; set; }
    }
}
