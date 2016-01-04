using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Theme
    {
        public static string InsUpdDelTheme(char Event, ThemeSetup obj, out int id)
        {
            id = 0;
            return DlTheme.InsUpdDelTheme(Event, obj, out id);
        }

        public static List<ThemeSetup> GetTheme(int Event, int id, string code, string code1)
        {

            var lst = new List<ThemeSetup>();
            var dt = DlTheme.GetTheme(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new ThemeSetup(Convert.ToInt32(dr["Id"]), dr["Category"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetUsersByTheme(int Event, int id, string code, string code1)
        {
            var dt = DlTheme.GetTheme(Event, id, code, code1);
            return dt;
        }
    }
}
