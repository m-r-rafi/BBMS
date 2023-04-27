using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BloodBankRepo : BaseRepo, IRepo<BloodBank, int, bool>
    {
        public List<BloodBank> Get()
        {
            return db.BloodBanks.ToList();
        }

        public BloodBank Get(int id)
        {
            return db.BloodBanks.Find(id);
        }

        public bool Insert(BloodBank obj)
        {
            db.BloodBanks.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(BloodBank obj)
        {
            var bank = Get(obj.Id);
            db.Entry(bank).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var bank = Get(id);
            db.BloodBanks.Remove(bank);
            return db.SaveChanges() > 0;
        }
    }
}
