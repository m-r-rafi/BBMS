using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DonateBloodRepo : BaseRepo, IDonateBloodRepo<DonateBlood, int, bool>
    {
        public List<DonateBlood> Get()
        {
            return db.DonateBloods.ToList();
        }

        public DonateBlood Get(int id)
        {
            return db.DonateBloods.Find(id);
        }

        public bool Insert(DonateBlood obj)
        {
            db.DonateBloods.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(DonateBlood obj)
        {
            var donate = Get(obj.Id);
            db.Entry(donate).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var donate = Get(id);
            db.DonateBloods.Remove(donate);
            return db.SaveChanges() > 0;
        }

        public List<DonateBlood> GetByUserId(int id)
        {
            var history = (from h in db.DonateBloods
                           where h.UserID == id
                           select h).ToList();
            foreach(var h in history)
            {
                h.StatusSetting = db.StatusSettings.FirstOrDefault(s => s.Id == h.StatusId);
                h.BloodBank = db.BloodBanks.FirstOrDefault(b => b.Id == h.BloodId);
            }
            return history;
        }
    }
}
