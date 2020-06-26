using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service.HR.Models
{
    public class CommendationModel : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public decimal Money { get; set; }
    }
}
