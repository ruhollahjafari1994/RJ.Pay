using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.Pay.Data.Dtos.Site.Admin
{
    public class UserForRegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Address { get; set; } 
        public string City { get; set; } 
        public bool IsActive { get; set; } 
        public bool Gender { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public bool Status { get; set; } 

    }
}
