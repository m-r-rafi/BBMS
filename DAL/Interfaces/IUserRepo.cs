﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepo<TYPE, ID, RET> : IRepo<TYPE, ID, RET>
    {
        RET IsEligible(ID id);
    }
}