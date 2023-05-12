using BLL.DTOs;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static List<UserDTO> Get()
        {
            return Convert(DataAccessFactory.UserData().Get());
        }
        public static UserDTO Get(int id)
        {
            return Convert(DataAccessFactory.UserData().Get(id));
        }
        public static bool Create(UserDTO user)
        {
            return DataAccessFactory.UserData().Insert(Convert(user));
        }

        public static bool Update(UserDTO user)
        {
            return DataAccessFactory.UserData().Update(Convert(user));
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }
        public static bool IsEligible(int id)
        {
            return DataAccessFactory.UserData().IsEligible(id);
        }
        public static bool IsEligibleUpdate(int id, DateTime date)
        {
            return DataAccessFactory.UserData().IsEligibleUpdate(id,date);
        }
        public static bool ChangePassword(int id, string currentPass, string newPass)
        {
            return DataAccessFactory.UserData().ChangePassword(id, currentPass, newPass);
        }
        public static List<UserDTO> DonorList(int id, string bloodName)
        {
            var user = Get(id);
            var users = Get().Where(u => u.BloodGroup == bloodName && IsEligible(u.Id)).ToList();
            var location = user.Address2;
            if (location.Contains(","))
            {
                location = location.Split(',')[0].Trim();
            }
            var matchedUsers = users.Where(u => u.Address2.Contains(location) && u.Id != id).ToList();
            var ids = matchedUsers.Select(o => o.Id).ToList();
            foreach (var v in users)
            {
                if (!ids.Contains(v.Id) && v.Id!=id)
                {
                    matchedUsers.Add(v);
                }
            }
            return matchedUsers;
        }
        static List<UserDTO> Convert(List<User> users)
        {
            var data = new List<UserDTO>();
            foreach (User user in users)
            {
                data.Add(Convert(user));
            }
            return data;
        }
        static UserDTO Convert(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Address1=user.Address1,
                Address2=user.Address2,
                BloodGroup= user.BloodGroup,
                Dob=user.Dob,
                Email=user.Email,
                FirstName=user.FirstName,
                Gender=user.Gender,
                LastDonatedOn=user.LastDonatedOn,
                LastName=user.LastName,
                Password=user.Password,
                UserName=user.UserName,
                UserTypeId=user.UserTypeId
            };
        }
        static User Convert(UserDTO user)
        {
            return new User()
            {
                Id = user.Id,
                Address1 = user.Address1,
                Address2 = user.Address2,
                BloodGroup = user.BloodGroup,
                Dob = user.Dob,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastDonatedOn = user.LastDonatedOn,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName,
                UserTypeId = user.UserTypeId
            };
        }
    }
}
