using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Text { get; set; }
        [Required]
        public System.DateTime TextedOn { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserTo { get; set; }
        [Required]
        public int UserFrom { get; set; }
        public virtual User User { get; set; }

    }
}
