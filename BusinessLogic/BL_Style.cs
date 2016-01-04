using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Style
    {
        public static string InsUpdDelStyle(char Event, StyleClass obj, out int id)
        {
            id = 0;
            return DlStyle.InsUpdDelStyle(Event, obj, out id);
        }

        public static List<StyleClass> GetStyleDetail(int Event, int id, string code, string code1)
        {

            var lst = new List<StyleClass>();
            var dt = DlStyle.GetStyle(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new StyleClass(Convert.ToInt32(dr["Id"]), dr["Style"].ToString(), dr["Description"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetStyleDetails(int Event, int id, string code, string code1)
        {
            var dt = DlStyle.GetStyle(Event, id, code, code1);
            return dt;
        }
    }
}
