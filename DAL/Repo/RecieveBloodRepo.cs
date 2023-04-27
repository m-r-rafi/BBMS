using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class RecieveBloodRepo : BaseRepo, IRecieveBloodRepo<RecieveBlood, int, bool>
    {
        public List<RecieveBlood> Get()
        {
            return db.RecieveBloods.ToList();
        }

        public RecieveBlood Get(int id)
        {
            return db.RecieveBloods.Find(id);
        }

        public bool Insert(RecieveBlood obj)
        {
            db.RecieveBloods.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(RecieveBlood obj)
        {
            var recieve = Get(obj.Id);
            db.Entry(recieve).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var recieve = Get(id);
            db.RecieveBloods.Remove(recieve);
            return db.SaveChanges() > 0;
        }
        public List<RecieveBlood> GetByUserId(int id)
        {
            var history = (from h in db.RecieveBloods
                           where h.UserID == id
                           select h).ToList();
            return history;
        }

    }
}
