﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.CommonModel
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
