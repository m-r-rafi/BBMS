using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validators
{
    public class AdultVerification: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                DateTime val = (DateTime)value;
                var diff = DateTime.Now - val;
                var year = diff.TotalDays / 365;
                if (year >= 18)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
