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
    public class BloodBankService
    {
        public static List<BloodBankDTO> Get()
        {
            return Convert(DataAccessFactory.BloodBankData().Get());
        }
        public static BloodBankDTO Get(int id)
        {
            return Convert(DataAccessFactory.BloodBankData().Get(id));
        }
        public static bool Create(BloodBankDTO bank)
        {
            return DataAccessFactory.BloodBankData().Insert(Convert(bank));
        }

        public static bool Update(BloodBankDTO bank)
        {
            return DataAccessFactory.BloodBankData().Update(Convert(bank));
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BloodBankData().Delete(id);
        }
        public static int AvailableBlood(string bloodName)
        {
            var blood = (from b in Get()
                         where b.BloodName == bloodName
                         select b).FirstOrDefault();
            return blood.Qty;
        }
        public static bool UpdateByAdmin(string bloodName, int bags)
        {
            var blood = Get().FirstOrDefault(b => b.BloodName == bloodName.Trim());
            blood.Qty += bags;
            if (blood.Qty < 0) return false;
            return Update(blood);
        }
        static List<BloodBankDTO> Convert(List<BloodBank> bank)
        {
            var data = new List<BloodBankDTO>();
            foreach (BloodBank b in bank)
            {
                data.Add(Convert(b));
            }
            return data;
        }
        static BloodBankDTO Convert(BloodBank bank)
        {
            return new BloodBankDTO()
            {
                Id = bank.Id,
                BloodName=bank.BloodName,
                Qty=bank.Qty

            };
        }
        static BloodBank Convert(BloodBankDTO bank)
        {
            return new BloodBank()
            {
                Id = bank.Id,
                BloodName = bank.BloodName,
                Qty = bank.Qty

            };
        }

        
    }
}
