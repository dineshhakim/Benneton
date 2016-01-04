using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
   public class BL_Knitting_SubCategory
    {
        public static string InsUpdDelKnittingSubCategory(char Event, KnittingSubCategory obj, out int id)
        {
            id = 0;
            return DlKnittingSubCategory.InsUpdDelKnittingSubCategory(Event, obj, out id);
        }

        public static List<KnittingSubCategory> GetKnittingSubCategory(int Event, int id, string code, string code1)
        {

            var lst = new List<KnittingSubCategory>();
            var dt = DlKnittingSubCategory.GetKnittingSubCategory(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new KnittingSubCategory(Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["Category_Id"]), dr["Category"].ToString(), dr["SubCategory"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetUsersByKnitting(int Event, int id, string code, string code1)
        {
            var dt = DlKnittingSubCategory.GetKnittingSubCategory(Event, id, code, code1);
            return dt;
        }
    }
}
