using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StatusSetting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }
        public virtual ICollection<DonateBlood> DonateBloods { get; set; }
        public virtual ICollection<RecieveBlood> RecieveBloods { get; set; }
        public StatusSetting()
        {
            this.DonateBloods = new HashSet<DonateBlood>();
            this.RecieveBloods = new HashSet<RecieveBlood>();
        }
    }
}
