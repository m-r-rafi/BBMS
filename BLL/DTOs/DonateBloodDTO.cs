using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DonateBloodDTO
    {
        public int Id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public System.DateTime DonatedOn { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int BloodId { get; set; }
        [Required]
        public int StatusId { get; set; }
    }
}
