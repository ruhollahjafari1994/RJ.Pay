﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MadPay724.Data.Models.MainDB
{
    public class Document : BaseEntity<string>
    {
        public Document()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
        [Required]
        public short Approve { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string Message { get; set; }
        [Required]
        public bool IsTrue { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string NationalCode { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string FatherNameRegisterCode { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 0)]
        public string Address { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 0)]
        public string PicUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
