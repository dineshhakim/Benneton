using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Bank_Desc
    {
        public static string InsUpdDelBankDetail(char Event, Bank obj, out int id)
        {
            id = 0;
            return DL_Bank_Desc.InsUpdDelBankDesc(Event, obj, out id);
        }
        public static DataTable GetIntAccumulate(int Event, int id, string code)
        {
            var dt = DL_Bank_Desc.GetIntAccumulate(Event, id, code);
            return dt;
        }
        public static DataTable GetIntCalMethod(int Event, int id, string code)
        {
            var dt = DL_Bank_Desc.GetIntCalMethod(Event, id, code);
            return dt;
        }
        public static DataTable GetBankDetails(int EVENT, int ID, string CODE)
        {
            return DL_Bank_Desc.GetBankDetails(EVENT, ID, CODE);
        }
        public static decimal GetBankBal(int bankId)
        {
            return DL_Bank_Desc.GetBankBal(bankId);
        }
    }
}
