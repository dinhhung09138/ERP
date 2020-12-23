using Core.CommonModel;
using Microsoft.AspNetCore.Http;
using Service.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.HR.Models
{
    public class LeaveStatusModel : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Link to Code table for getting data.
        /// </summary>
        [Required]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
