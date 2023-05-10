using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBMS.Models
{
    public class RequestBloodModel
    {
        public int UserId { get; set; }
        public string BloodName { get; set; }
        public int Bags { get; set; }
    }
}