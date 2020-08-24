using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.System.Models
{
    public class RoleModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
