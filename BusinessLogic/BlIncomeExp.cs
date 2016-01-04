using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BlIncomeExp
    {
        
        public static DataTable GetIncomeExp(int EVENT, int ID, string CODE)
        {
            return DlIncomeExp.GetIncomeExp(EVENT, ID, CODE);
        }

        public string InsUpdDelIncomeExp(PL_IncomeExp obj, out int Id)
        {
            return DlIncomeExp.InsUpdDelIncomeExp(obj, out Id);
        }
        public static string GetIE_CODE(int EVENT, int ID, string CODE)
        {
            return DlIncomeExp.GetIE_CODE(EVENT, ID, CODE);
        }
        public static string GetIEForIeCode(string code, string type)
        {
            return DlIncomeExp.GetIEForIeCode(code, type);
        }
        public static string GetIECodeForIe(string code, string type)
        {
            return DlIncomeExp.GetIECodeForIe(code, type);
        }
        public static string GetIeParent(string code, string type, string glcode)
        {
            return DlIncomeExp.GetIeParent(code, type, glcode);
        }
    }
}
