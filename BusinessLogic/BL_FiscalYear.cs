using System;
using System.Collections.Generic;
using System.Data;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_FiscalYear
    {
       public static string InsUpdDelFiscalYear(char Event, FiscalYear obj, out int id)
        {
            id = 0;
            return DlFiscalYear.InsUpdDelFiscalYear(Event, obj, out id);
        }

        public static List<FiscalYear> GetFiscalYears(int Event, int id, string code)
        {

            var lst = new List<FiscalYear>();
            var dt = DlFiscalYear.GetFiscalYear(Event, id, code);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new FiscalYear(Convert.ToInt32(dr["Id"]), Convert.ToDateTime(dr["StartDate"].ToString()), Convert.ToDateTime(dr["EndDate"].ToString()), Convert.ToBoolean(dr["IsCurrent"].ToString()));
                    lst.Add(obj);
                }
            }
            return lst;
        }
    }
}
