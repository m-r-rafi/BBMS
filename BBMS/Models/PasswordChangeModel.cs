using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBMS.Models
{
    public class PasswordChangeModel
    {
        public int id { get; set; }
        public string currentPass { get; set; }
        public string newPass { get; set; }
        public string confirmPass { get; set; }

    }
}