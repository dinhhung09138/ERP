using Core.CommonModel;
using Microsoft.AspNetCore.Http;
using Service.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class LeaveTypeModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string Code { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumOfDay { get; set; }

        [Required]
        public bool IsDeductible { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
