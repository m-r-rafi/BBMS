using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ChatRepo : BaseRepo, IRepo<Chat, int, bool>
    {
        public List<Chat> Get()
        {
            return db.Chats.ToList();
        }

        public Chat Get(int id)
        {
            return db.Chats.Find(id);
        }

        public bool Insert(Chat obj)
        {
            db.Chats.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Chat obj)
        {
            var chat = Get(obj.Id);
            db.Entry(chat).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var chat = Get(id);
            db.Chats.Remove(chat);
            return db.SaveChanges() > 0;
        }
    }
}
