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
        public static bool ChangeStatus(int receiveId, int statusId)
        {
            var receive = Get(receiveId);
            receive.StatusId = statusId;
            if (statusId == 4)
            {
                var user = UserService.Get(receive.UserID);
                user.LastDonatedOn = DateTime.Now;
                var bloodBank = BloodBankService.Get(receive.BloodId);
                bloodBank.Qty -= receive.Qty;
                var successBloodbank = BloodBankService.Update(bloodBank);
                if (successBloodbank)
                {
                    return Update(receive);
                }
                return false;
            }
            return Update(receive);
        }
        public static ReceiveChangeStatusDTO ViewChangeStatus(int receiveId)
        {
            var receive = Get(receiveId);
            ReceiveChangeStatusDTO res = new ReceiveChangeStatusDTO()
            {
                ReceiveUser = receive
            };
            res.Statuses = new List<StatusSettingDTO>();
            if (receive.StatusId == 1)
            {
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(2)));
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(3)));
            }
            else if (receive.StatusId == 2)
            {
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(3)));
                res.Statuses.Add(Convert(DataAccessFactory.StatusSettingData().Get(4)));
            }
            return res;
        }
        public static List<RecieveBloodDTO> GetAllByStatus(int id)
        {
            var receive = (from g in Get()
                           where g.StatusId == id
                           select g).ToList();
            return receive;
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
            if (recieve.User != null)
            {
                var User = new UserDTO()
                {
                    Id = recieve.User.Id,
                    Address1 = recieve.User.Address1,
                    Address2 = recieve.User.Address2,
                    BloodGroup = recieve.User.BloodGroup,
                    Dob = recieve.User.Dob,
                    Email = recieve.User.Email,
                    FirstName = recieve.User.FirstName,
                    Gender = recieve.User.Gender,
                    LastDonatedOn = recieve.User.LastDonatedOn,
                    LastName = recieve.User.LastName,
                    Password = recieve.User.Password,
                    UserName = recieve.User.UserName,
                    UserTypeId = recieve.User.UserTypeId
                };
                Receive.User = User;
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
