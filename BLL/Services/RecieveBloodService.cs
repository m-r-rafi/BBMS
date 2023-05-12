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
    public class RecieveBloodService
    {
        public static List<RecieveBloodDTO> Get()
        {
            return Convert(DataAccessFactory.RecieveBloodData().Get());
        }
        public static RecieveBloodDTO Get(int id)
        {
            return Convert(DataAccessFactory.RecieveBloodData().Get(id));
        }
        public static bool Create(RecieveBloodDTO recieve)
        {
            return DataAccessFactory.RecieveBloodData().Insert(Convert(recieve));
        }

        public static bool Update(RecieveBloodDTO recieve)
        {
            return DataAccessFactory.RecieveBloodData().Update(Convert(recieve));
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RecieveBloodData().Delete(id);
        }
        public static List<RecieveBloodDTO> GetByUserId(int id)
        {
            return Convert(DataAccessFactory.RecieveBloodData().GetByUserId(id));
        }
        public static bool RequestBlood(int userId, string bloodName, int bags)
        {
            var user = DataAccessFactory.UserData().Get(userId);
            var blood = (from b in DataAccessFactory.BloodBankData().Get()
                         where b.BloodName == bloodName
                         select b).FirstOrDefault();
            if (blood.Qty < bags) return false;
            if (!IsAllowedRequest(userId)) return false;
            RecieveBloodDTO objToSave = new RecieveBloodDTO()
            {
                BloodId = blood.Id,
                Qty = bags,
                RecievedOn = DateTime.Now,
                UserID = user.Id,
                StatusId = 1
            };
            return Create(objToSave);
        }
        public static bool IsAllowedRequest(int id)
        {
            var recieve = DataAccessFactory.RecieveBloodData().GetByUserId(id).OrderByDescending(d => d.RecievedOn).FirstOrDefault();
            if (recieve == null || recieve.StatusId == 4 || recieve.StatusId == 3) return true;
            return false;
        }
        public static List<RecieveBloodDTO> GetByUserIdStatus(int id, int statusId)
        {
            var receives = GetByUserId(id);
            receives = (from d in receives
                        where d.StatusId == statusId
                       select d).ToList();
            return receives;
        }
        
        static List<RecieveBloodDTO> Convert(List<RecieveBlood> recieve)
        {
            var data = new List<RecieveBloodDTO>();
            foreach (RecieveBlood r in recieve)
            {
                data.Add(Convert(r));
            }
            return data;
        }
        static RecieveBloodDTO Convert(RecieveBlood recieve)
        {
            var Receive = new RecieveBloodDTO()
            {
                Id = recieve.Id,
                BloodId = recieve.BloodId,
                RecievedOn = recieve.RecievedOn,
                Qty = recieve.Qty,
                StatusId = recieve.StatusId,
                UserID = recieve.UserID,

            };
            if(recieve.BloodBank != null)
            {
                var BloodBank = new BloodBankDTO()
                {

                    BloodName = recieve.BloodBank.BloodName,
                    Id = recieve.BloodBank.Id,
                    Qty = recieve.BloodBank.Qty
                };
                Receive.BloodBank = BloodBank;
            }
            if (recieve.StatusSetting != null)
            {
                var Status = new StatusSettingDTO()
                {
                    Id = recieve.StatusSetting.Id,
                    StatusName = recieve.StatusSetting.StatusName
                };
                Receive.StatusSetting = Status;
            }
            return Receive;
        }
        static RecieveBlood Convert(RecieveBloodDTO recieve)
        {
            return new RecieveBlood()
            {
                Id = recieve.Id,
                BloodId = recieve.BloodId,
                RecievedOn = recieve.RecievedOn,
                Qty = recieve.Qty,
                StatusId = recieve.StatusId,
                UserID = recieve.UserID,
            };
        }
    }
}
