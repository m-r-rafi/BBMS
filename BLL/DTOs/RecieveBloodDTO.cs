using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecieveBloodDTO
    {
        public int Id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public System.DateTime RecievedOn { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int BloodId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public BloodBankDTO BloodBank { get; set; }
        public StatusSettingDTO StatusSetting { get; set; }
        public UserDTO User { get; set; }
    }
}
