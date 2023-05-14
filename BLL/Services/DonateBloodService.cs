using BLL.DTOs;
using BLL.Helper;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DonateBloodService
    {
        public static List<DonateBloodDTO> Get()
        {
            return Convert(DataAccessFactory.DonateBloodData().Get());
        }
        public static DonateBloodDTO Get(int id)
        {
            return Convert(DataAccessFactory.DonateBloodData().Get(id));
        }
        public static bool Create(DonateBloodDTO donate)
        {
            return DataAccessFactory.DonateBloodData().Insert(Convert(donate));
        }

        public static bool Update(DonateBloodDTO donate)
        {
            return DataAccessFactory.DonateBloodData().Update(Convert(donate));
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.DonateBloodData().Delete(id);
        }
        public static List<DonateBloodDTO> GetByUserId(int id)
        {
            return Convert(DataAccessFactory.DonateBloodData().GetByUserId(id));
        }
        public static List<DonateBloodDTO> GetAllByStatus(int id)
        {
            var donate = (from g in Get()
                           where g.StatusId == id
                           select g).ToList();
            return donate;
        }
        public static List<DonateBloodDTO> GetByUserIdStatus(int id, int statusId)
        {
            var donates = GetByUserId(id);
            donates = (from d in donates
                       where d.StatusId == statusId
                       select d).ToList();
            return donates;
        }
        public static bool Donate(int id)
        {
            if (!DataAccessFactory.UserData().IsEligible(id)) return false;
            var user = DataAccessFactory.UserData().Get(id);
            var bloods = DataAccessFactory.BloodBankData().Get();
            var blood = (from b in bloods
                         where user.BloodGroup == b.BloodName
                         select b).FirstOrDefault();
            if (blood == null) return false;
            DonateBlood objToSave = new DonateBlood()
            {
                BloodId = blood.Id,
                Qty = 1,
                UserID = user.Id,
                StatusId = 1,
                DonatedOn = DateTime.Now
            };
            return DataAccessFactory.DonateBloodData().Insert(objToSave);
        }
        public static bool IsAllowedRequest(int id)
        {
            var donate = DataAccessFactory.DonateBloodData().GetByUserId(id).OrderByDescending(d=>d.DonatedOn).FirstOrDefault();
            if (donate == null || donate.StatusId == 4 || donate.StatusId == 3) return true;
            return false;
        }
        public static DonateChangeStatusDTO ViewChangeStatus(int donateId)
        {
            var donate = Get(donateId);
            DonateChangeStatusDTO res = new DonateChangeStatusDTO()
            {
                DonateUser = donate
            };
            res.Statuses = new List<StatusSettingDTO>();
            if (donate.StatusId == 1)
            {
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(2)));
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(3)));
            }
            else if(donate.StatusId == 2)
            {
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(3)));
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(4)));
            }
            return res;
        }
        static List<DonateBloodDTO> Convert(List<DonateBlood> donate)
        {
            var data = new List<DonateBloodDTO>();
            foreach (DonateBlood d in donate)
            {
                data.Add(Convert(d));
            }
            return data;
        }
        static DonateBloodDTO Convert(DonateBlood donate)
        {
            var Donate = new DonateBloodDTO()
            {
                Id = donate.Id,
                BloodId = donate.BloodId,
                DonatedOn = donate.DonatedOn,
                Qty = donate.Qty,
                StatusId = donate.StatusId,
                UserID = donate.UserID
            };
            if(donate.BloodBank != null)
            {
                var BloodBank = new BloodBankDTO()
                {
                    BloodName = donate.BloodBank.BloodName,
                    Id = donate.BloodBank.Id,
                    Qty = donate.BloodBank.Qty
                };
                Donate.BloodBank = BloodBank;
            }
            if (donate.StatusSetting != null)
            {
                var Status = new StatusSettingDTO()
                {
                    Id = donate.StatusSetting.Id,
                    StatusName = donate.StatusSetting.StatusName
                };
                Donate.StatusSetting = Status;
            }
            if(donate.User != null)
            {
                var User = new UserDTO()
                {
                    Id = donate.User.Id,
                    Address1 = donate.User.Address1,
                    Address2 = donate.User.Address2,
                    BloodGroup = donate.User.BloodGroup,
                    Dob = donate.User.Dob,
                    Email = donate.User.Email,
                    FirstName = donate.User.FirstName,
                    Gender = donate.User.Gender,
                    LastDonatedOn = donate.User.LastDonatedOn,
                    LastName = donate.User.LastName,
                    Password = donate.User.Password,
                    UserName = donate.User.UserName,
                    UserTypeId = donate.User.UserTypeId
                };
                Donate.User = User;
            }

            return Donate;
        }

        public static bool ChangeStatus(int donateId, int statusId)
        {
            var donate = Get(donateId);
            donate.StatusId = statusId;
            if(statusId == 4)
            {
                var user = UserService.Get(donate.UserID);
                user.LastDonatedOn = DateTime.Now;
                var bloodBank = BloodBankService.Get(donate.BloodId);
                bloodBank.Qty += donate.Qty;
                var successBloodbank = BloodBankService.Update(bloodBank);
                var successUser = UserService.UpdateBySystem(user);
                if (successBloodbank && successUser)
                {
                    return Update(donate);
                }
                return false;
            }
            if(statusId == 2)
            {
                Email.SendEmail(donate.User.Email, "BloodBank: Notification", "Your Request has been accepted. Please come to this location To Donate Blood :- SaveLives, House-720,Road-18,Agargaon ");
            }
            if (statusId == 3)
            {
                Email.SendEmail(donate.User.Email, "BloodBank: Notification", "Sorry! Your Request of donating blood has been rejected. Please contact with the administrator for further query");
            }

            return Update(donate);
        }

        static DonateBlood Convert(DonateBloodDTO donate)
        {
            return new DonateBlood()
            {
                Id = donate.Id,
                BloodId = donate.BloodId,
                DonatedOn = donate.DonatedOn,
                Qty = donate.Qty,
                StatusId = donate.StatusId,
                UserID = donate.UserID,
            };
        }
        static StatusSettingDTO Convert(StatusSetting status)
        {
            return new StatusSettingDTO()
            {
                Id = status.Id,
                StatusName = status.StatusName
            };
        }
    }
}
