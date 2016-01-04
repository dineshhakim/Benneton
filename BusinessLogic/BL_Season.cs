using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataLogic;
using Domain;

namespace BusinessLogic
{
    public class BL_Season
    {
        public static string InsUpdDelSeason(char Event, SeasonClass obj, out int id)
        {
            id = 0;
            return DlSeason.InsUpdDelSeason(Event, obj, out id);
        }

        public static List<SeasonClass> GetSeason(int Event, int id, string code, string code1)
        {

            var lst = new List<SeasonClass>();
            var dt = DlSeason.GetSeason(Event, id, code, code1);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var obj = new SeasonClass(Convert.ToInt32(dr["Id"]), dr["Season"].ToString());
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static DataTable GetAllSeason(int Event, int id, string code, string code1)
        {
            var dt = DlSeason.GetSeason(Event, id, code, code1);
            return dt;
        }
     
    }
}
