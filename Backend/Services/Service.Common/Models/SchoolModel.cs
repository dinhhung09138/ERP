using Core.CommonModel;
using System.ComponentModel.DataAnnotations;

namespace Service.Common.Models
{
    public class SchoolModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
