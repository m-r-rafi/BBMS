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
        public static IUserRepo<User, int, bool> UserData()
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
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }
    }
}
