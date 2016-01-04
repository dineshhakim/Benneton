using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Theme_Sub_Category
    {
        public static string InsUpdDelThemeSubCategory(char Event, ThemeSetupSubCategory obj, out int id)
        {
            id = 0;
            return DlThemeSubCategory.InsUpdDelThemeSubCategory(Event, obj, out id);
        }

        public static List<ThemeSetupSubCategory> GetThemeSubCategory(int Event, int id, string code, string code1)
        {

            var lst = new List<ThemeSetupSubCategory>();
            var dt = DlThemeSubCategory.GetThemeSUbCategory(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new ThemeSetupSubCategory(Convert.ToInt32(dr["Id"]),Convert.ToInt32(dr["Category_Id"]),dr["Category"].ToString(), dr["SubCategory"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetUsersByTheme(int Event, int id, string code, string code1)
        {
            var dt = DlThemeSubCategory.GetThemeSUbCategory(Event, id, code, code1);
            return dt;
        }
    }
}
