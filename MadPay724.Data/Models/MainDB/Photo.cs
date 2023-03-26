﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MadPay724.Data.Models.MainDB
{
    public class Photo : BaseEntity<string>
    {
        public Photo()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
        [Required]
        [StringLength(1000, MinimumLength = 0)]
        public string Url { get; set; }
        [StringLength(500, MinimumLength = 0)]
        public string Description { get; set; }
        [StringLength(500, MinimumLength = 0)]
        public string Alt { get; set; }
        [Required]
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
