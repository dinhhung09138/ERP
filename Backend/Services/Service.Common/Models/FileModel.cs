using Core.CommonModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Service.Common.Models
{
    public class FileModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string EmployeeCode { get; set; }

        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        public decimal Size { get; set; }

        public string MineType { get; set; }

        public string Extension { get; set; }

        public string SystemFileName { get; set; }

        public string FilePath { get; set; }

        public string FilePath32 { get; set; }

        public string FilePath64 { get; set; }

        public string FilePath128 { get; set; }

        public bool WaitForDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public IFormFile? File { get; set; }
    }
}
