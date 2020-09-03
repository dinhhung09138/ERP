using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
