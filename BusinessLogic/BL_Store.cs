using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Store
    {
        public static string InsUpdDelStore(char Event, Store obj, out int id)
        {
            id = 0;
            return DlStore.InsUpdDelStore(Event, obj, out id);
        }

        public static List<Store> GetColorDetail(int Event, int id, string code, string code1)
        {

            var lst = new List<Store>();
            var dt = DlStore.GetStoreDetail(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new Store(Convert.ToInt32(dr["Id"]), int.Parse(dr["Store_No"].ToString()), dr["Store_Name"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetStoreDetails(int Event, int id, string code, string code1)
        {
            var dt = DlStore.GetStoreDetail(Event, id, code, code1);
            return dt;
        }
    }
}
