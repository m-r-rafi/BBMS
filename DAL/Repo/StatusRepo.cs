using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class StatusRepo : BaseRepo, IRepo<StatusSetting, int, bool>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<StatusSetting> Get()
        {
            return db.StatusSettings.ToList();
        }

        public StatusSetting Get(int id)
        {
            return db.StatusSettings.Find(id);
        }

        public bool Insert(StatusSetting obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(StatusSetting obj)
        {
            throw new NotImplementedException();
        }
    }
}
