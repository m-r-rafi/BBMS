﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepo<TYPE, ID,Date ,RET,STR> : IRepo<TYPE, ID, RET>
    {
        RET IsEligible(ID id);
        RET IsEligibleUpdate(ID id, Date date);
        RET ChangePassword(ID id, STR currentPass, STR newPass);
        RET UpdateBySystem(TYPE obj);
    }
}
