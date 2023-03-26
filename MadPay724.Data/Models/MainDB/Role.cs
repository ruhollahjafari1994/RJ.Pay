﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace MadPay724.Data.Models.MainDB
{
   public class Role : IdentityRole
    {
       
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
