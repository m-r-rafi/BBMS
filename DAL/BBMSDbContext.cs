using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BBMSDbContext:DbContext
    {
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<StatusSetting> StatusSettings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RecieveBlood> RecieveBloods { get; set; }
        public DbSet<DonateBlood> DonateBloods { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Token> Tokens { get; set; }

    }
}
