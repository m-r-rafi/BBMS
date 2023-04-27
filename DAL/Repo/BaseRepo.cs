using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BaseRepo
    {
        internal BBMSDbContext db;
        internal BaseRepo()
        {
            db = new BBMSDbContext();
        }
    }
}
