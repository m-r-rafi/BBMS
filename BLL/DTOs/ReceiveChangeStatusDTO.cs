using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReceiveChangeStatusDTO
    {
        public RecieveBloodDTO ReceiveUser { get; set; }
        public List<StatusSettingDTO> Statuses { get; set; }
    }
}
