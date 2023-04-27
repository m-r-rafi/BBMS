using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRecieveBloodRepo<TYPE, ID, RET> : IRepo<TYPE, ID, RET>
    {
        List<TYPE> GetByUserId(ID id);
    }
}
