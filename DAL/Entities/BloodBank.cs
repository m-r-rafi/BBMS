using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BloodBank
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string BloodName { get; set; }
        [Required]
        public int Qty { get; set; }
        public virtual ICollection<DonateBlood> DonateBloods { get; set; }
        public virtual ICollection<RecieveBlood> RecieveBloods { get; set; }
        public BloodBank()
        {
            this.DonateBloods = new List<DonateBlood>();
            this.RecieveBloods = new List<RecieveBlood>();
        }

    }
}
