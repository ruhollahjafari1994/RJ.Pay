﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MadPay724.Data.Dtos.Site.Panel.BlogGroup
{
   public class BlogGroupForCreateUpdateDto
    {
        [Required]
        [StringLength(450, MinimumLength = 0)]
        public string Parent { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 0)]
        public string Name { get; set; }
    }
}
