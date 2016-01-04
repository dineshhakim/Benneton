using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Size
    {
        public static string InsUpdDelSize(char Event, SizeClass obj, out int id)
        {
            id = 0;
            return DlSize.InsUpdDelSize(Event, obj, out id);
        }

        public static List<SizeClass> GetSize(int Event, int id, string code, string code1)
        {

            var lst = new List<SizeClass>();
            var dt = DlSize.GetSize(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new SizeClass(Convert.ToInt32(dr["Id"]), dr["Size"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetUsersBySize(int Event, int id, string code, string code1)
        {
            var dt = DlSize.GetSize(Event, id, code, code1);
            return dt;
        }
    }
}
