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
            return new RecieveBloodDTO()
            {
                Id = recieve.Id,
                BloodId = recieve.BloodId,
                RecievedOn = recieve.RecievedOn,
                Qty = recieve.Qty,
                StatusId = recieve.StatusId,
                UserID = recieve.UserID,

            };
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
