using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
  public  class BL_Knitting_Category
    {
      public static string InsUpdDelKnittingCategory(char Event, KnittingCategory obj, out int id)
        {
            id = 0;
            return DlKnittingCategory.InsUpdDelKnittingCategory(Event, obj, out id);
        }

      public static List<KnittingCategory> GetKnittingCategory(int Event, int id, string code, string code1)
        {

            var lst = new List<KnittingCategory>();
            var dt = DlKnittingCategory.GetKnittingCategory(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new KnittingCategory(Convert.ToInt32(dr["Id"]), dr["Category"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetAllKnittingCategory(int Event, int id, string code, string code1)
        {
            var dt = DlKnittingCategory.GetKnittingCategory(Event, id, code, code1);
            return dt;
        }
    }
}
