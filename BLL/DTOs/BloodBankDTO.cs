using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BloodBankDTO
    {
        public int Id { get; set; }
        [Required]
        public string BloodName { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
