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

            return Donate;
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
    }
}
