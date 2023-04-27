﻿using BLL.DTOs;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string uname, string pass)
        {
            var res = DataAccessFactory.AuthData().Authenticate(uname, pass);
            if (res)
            {
                var token = new Token() {
                    UserID = uname,
                    CreatedAt = DateTime.Now,
                    TKey = Guid.NewGuid().ToString()
                };
                var ret = DataAccessFactory.TokenData().Insert(token);
                if(ret != null)
                {
                    return Convert(ret);
                }

            }
            return null;
        }
        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (extk != null && extk.ExpiredAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool LogOut(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            extk.ExpiredAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;
        }
        static TokenDTO Convert(Token token)
        {
            return new TokenDTO()
            {
                CreatedAt = token.CreatedAt,
                ExpiredAt = token.ExpiredAt,
                TKey = token.TKey,
                UserID = token.UserID
            };
        }

    }
}
