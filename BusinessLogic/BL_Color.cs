using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Color
    {
        public static string InsUpdDelColor(char Event, Color obj, out int id)
        {
            id = 0;
            return DlColorSetup.InsUpdDelColor(Event, obj, out id);
        }

        //public static List<Color> GetColorDetail(int Event, int id, string code, string code1)
        //{

        //    var lst = new List<Color>();
        //    var dt = DlColorSetup.GetColorDetail(Event, id, code, code1);
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            var obj = new Color(Convert.ToInt32(dr["Id"]),dr["Category"].ToString(),dr["Style"].ToString(), dr["Color_Code"].ToString(),dr["Color_Name"].ToString());
        //            lst.Add(obj);
        //        }
        //    }
        //    return lst;
        //}
        public static DataTable GetColorDetails(int Event, int id, int id1, string code1)
        {
            var dt = DlColorSetup.GetColorDetail(Event, id, id1, code1);
            return dt;
        }
    }
}
