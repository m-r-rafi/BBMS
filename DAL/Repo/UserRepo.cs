﻿using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo:BaseRepo, IUserRepo<User, int,DateTime ,bool,string>, IAuth<User>
    {
        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Insert(User obj)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == obj.UserName);
            if (user != null)
                return false;
            db.Users.Add(obj);
            if (obj.LastDonatedOn == null || obj.LastDonatedOn == DateTime.MinValue)
                obj.LastDonatedOn = DateTime.Now.AddYears(-10);
            return db.SaveChanges() > 0;
        }
        public bool UpdateBySystem(User obj)
        {
            var user = Get(obj.Id);
            db.Entry(user).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(User obj)
        {
            var users = Get(obj.Id);
            obj.Password = users.Password;
            obj.Gender = users.Gender;
            obj.BloodGroup = users.BloodGroup;
            obj.Dob = users.Dob;
            obj.LastDonatedOn = users.LastDonatedOn;
            db.Entry(users).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var user = Get(id);
            db.Users.Remove(user);
            return db.SaveChanges() > 0;
        }
        public bool ChangePassword(int id, string currentPass, string newPass)
        {
            var user = Get(id);
            if (user.Password != currentPass) return false;
            if (newPass == null || newPass.Length < 1) return false;
            user.Password = newPass;
            return Update(user);
        }

        public bool IsEligible(int id)
        {
            var user = (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            if (user == null) return false;
            var DOB = DateTime.Now - user.Dob;
            var year = DOB.TotalDays / 365;
            var months = DateTime.Now - user.LastDonatedOn;
            var month = months.TotalDays / 30;
            if (year >= 18 && month > 4)
            {
                return true;
            }
            else return false;

        }

        public bool IsEligibleUpdate(int id, DateTime date)
        {
            var user = (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            if (user == null) return false;
            if (date < user.LastDonatedOn) return false;
            var Date = date - user.LastDonatedOn;
            var month = Date.TotalDays / 30;
            if (month < 4) return false;
            try
            {

                user.LastDonatedOn = date;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public User Authenticate(string uname, string password)
        {
            var data = db.Users.FirstOrDefault(u => (u.UserName.Equals(uname) || u.Email.Equals(uname)) && u.Password.Equals(password));
            return data;
        }
    }
}
