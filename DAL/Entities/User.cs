using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public System.DateTime Dob { get; set; }
        [Required]
        [StringLength(50)]
        public string Address1 { get; set; }
        [Required]
        [StringLength(50)]
        public string Address2 { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public System.DateTime LastDonatedOn { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string BloodGroup { get; set; }
        [Required]
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<DonateBlood> DonateBloods { get; set; }
        public virtual ICollection<RecieveBlood> RecieveBloods { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public User()
        {
                this.DonateBloods = new List<DonateBlood>();
                this.RecieveBloods = new List<RecieveBlood>();
                this.Chats = new List<Chat>();
        }


    }
}
