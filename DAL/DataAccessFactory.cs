using DAL.Entities;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IUserRepo<User, int,DateTime ,bool> UserData()
        {
            return new UserRepo();
        }
        public static IRepo<BloodBank, int, bool> BloodBankData()
        {
            return new BloodBankRepo();
        }
        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IAuth<User> AuthData()
        {
            return new UserRepo();
        }
        public static IDonateBloodRepo<DonateBlood, int, bool> DonateBloodData()
        {
            return new DonateBloodRepo();
        }
        public static IRecieveBloodRepo<RecieveBlood, int, bool> RecieveBloodData()
        {
            return new RecieveBloodRepo();
        }
        public static IRepo<Chat, int, bool> ChatData()
        {
            return new ChatRepo();
        }
    }
}
