using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloodBank.Prototype.Models
{
    public class SignUpModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public System.DateTime Dob { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public System.DateTime LastDonatedOn { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string BloodGroup { get; set; }
    }
}