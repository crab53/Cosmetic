﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetic.Bussiness.DTO
{
    public class UserDTO:BaseDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string Phone { get; set; }
        
    }
}
