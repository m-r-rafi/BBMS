using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RecieveBlood
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public System.DateTime RecievedOn { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [Required]
        [ForeignKey("BloodBank")]
        public int BloodId { get; set; }
        public virtual BloodBank BloodBank { get; set; }
        [Required]
        [ForeignKey("StatusSetting")]
        public int StatusId { get; set; }
        public virtual StatusSetting StatusSetting { get; set; }
    }
}
