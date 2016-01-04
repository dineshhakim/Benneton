using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Gender
    {
        public static string InsUpdDelGender(char Event, GenderClass obj, out int id)
        {
            id = 0;
            return DlGender.InsUpdDelGender(Event, obj, out id);
        }

        public static List<GenderClass> GetGender(int Event, int id, string code, string code1)
        {

            var lst = new List<GenderClass>();
            var dt = DlGender.GetGender(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new GenderClass(Convert.ToInt32(dr["Id"]), dr["Category"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetAllGender(int Event, int id, string code, string code1)
        {
            var dt = DlGender.GetGender(Event, id, code, code1);
            return dt;
        }
    }
}
