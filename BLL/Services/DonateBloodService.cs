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
            return new DonateBloodDTO()
            {
                Id = donate.Id,
                BloodId=donate.BloodId,
                DonatedOn=donate.DonatedOn,
                Qty=donate.Qty,
                StatusId=donate.StatusId,
                UserID=donate.UserID,
                
               
            };
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
