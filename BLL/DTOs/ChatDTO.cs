using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ChatDTO
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public System.DateTime TextedOn { get; set; }
        [Required]
        public int UserTo { get; set; }
        [Required]
        public int UserFrom { get; set; }
    }
}
