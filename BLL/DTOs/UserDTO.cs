using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
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
        public string Password { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public int UserTypeId { get; set; }
    }
}
